using System.Linq;
using Core.Logic.Shop.Data;
using Core.Logic.Shop.Infrastructure;
using Core.Logic.Shop.Interfaces;
using Core.Services.SaveLoadService;
using Cysharp.Threading.Tasks;

namespace Core.Logic.Shop
{
    public class ShopOffersDataAdapter : IShopOffersDataAdapter
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly ICoinOffersDataAdapter _coinOffersDataAdapter;

        public ShopOffersDataAdapter(ISaveLoadService saveLoadService, ICoinOffersDataAdapter coinOffersDataAdapter)
        {
            _saveLoadService = saveLoadService;
            _coinOffersDataAdapter = coinOffersDataAdapter;
        }

        public async UniTask<IShopCoinOfferModel> GetCoinOfferData(string coinOfferId)
        {
            var coinOfferData = _coinOffersDataAdapter.GetCoinOfferData(coinOfferId);
            
            bool isOfferActive = coinOfferData.OfferIsActive;
            int coinValue = coinOfferData.CoinValue;
            float price = coinOfferData.Price;
            OfferNoticeType noticeType = coinOfferData.NoticeType;

            CheckOfferNoticeType(ref noticeType);

            IShopCoinOfferModel shopCoinOfferModel = new ShopCoinOfferModel(
                isOfferActive,
                coinOfferId,
                coinValue,
                price,
                noticeType);

            return shopCoinOfferModel;
        }

        private void CheckOfferNoticeType(ref OfferNoticeType noticeType)
        {
            if (noticeType == OfferNoticeType.FirstPurchase)
            {
                var currentData = _saveLoadService.CurrentData;
                if (currentData.Purchases != null && currentData.Purchases.Any())
                {
                    noticeType = OfferNoticeType.None;
                }
            }
        }
    }
}