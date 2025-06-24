using System;
using Core.Logic.Shop.Infrastructure;
using Core.Logic.Shop.Interfaces;
using Core.Managers.ScreenManager;
using Core.Services.LoadingScreenService.Interfaces;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Logic.Shop
{
    public class ShopPresenter : IShopPresenter, IInitializable, IDisposable
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly IShopService _shopService;
        
        private IShopView _view;
        
        public bool IsActive { get; private set; }
        
        public event Action OnBack;

        public ShopPresenter(ICoreScreenManager coreScreenManager, IShopService shopService)
        {
            _coreScreenManager = coreScreenManager;
            _shopService = shopService;

            IsActive = false;
        }
        
        public void Initialize()
        {
            _shopService.OnCoinOffersUpdated += UpdateCoinOffers;
        }
        
        public async UniTask ShowView()
        {
            IsActive = true;
            
            _view = await _coreScreenManager.ShowCoreAsync<IShopView>(ResourcesProvider.UI.ShopView);

            await InitializeCoinOffers();
            
            _view.Initialize(BackEvent, CoinOfferSelectedHandler);
        }

        public void HideView()
        {
            IsActive = false;
            
            if (_view != null)
            {
                _view.Hide();
            }
        }

        private async UniTask InitializeCoinOffers()
        {
            if(_view == null)
                return;
            
            var coinOfferViews = _view.CoinOffers;
            
            foreach (var coinOfferView in coinOfferViews)
            {
                var coinOfferData = await _shopService.GetCoinOfferData(coinOfferView.CoinOfferId);

                string coinValue = coinOfferData.CoinValue.ToString();
                string price = $"{coinOfferData.Price}$";
                
                coinOfferView.Initialize(price, coinValue, CoinOfferSelectedHandler);
                
                OfferNoticeType notice = coinOfferData.NoticeType;
                
                if (notice != OfferNoticeType.None)
                {
                    string noticeMessage = GetCoinNoticeMessage(notice);
                    coinOfferView.ShowNotice(noticeMessage);
                }
                else
                {
                    coinOfferView.HideNotice();
                }
            }
        }

        private async void CoinOfferSelectedHandler(string coinOfferId)
        {
            await _shopService.BuyCoinOffer(coinOfferId);
        }

        private string GetCoinNoticeMessage(OfferNoticeType notice)
        {
            switch (notice)
            {
                case OfferNoticeType.FirstPurchase:
                    return "first \npurchase";
                case OfferNoticeType.BestOffer:
                    return "best offer";
                default:
                    return "";
            }
        }

        private void UpdateCoinOffers()
        {
            InitializeCoinOffers();
        }
        
        private void BackEvent() => OnBack?.Invoke();

        public void Dispose()
        {
            _shopService.OnCoinOffersUpdated -= UpdateCoinOffers;
        }
    }
}