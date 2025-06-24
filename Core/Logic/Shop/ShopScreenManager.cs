using System;
using Core.Logic.Shop.Interfaces;
using Core.Logic.Wallet.Interfaces;
using Core.Services.LoadingScreenService.Interfaces;
using UnityEngine;
using Zenject;

namespace Core.Logic.Shop
{
    public class ShopScreenManager : IShopScreenManager, IInitializable, IDisposable
    {
        private readonly IShopPresenter _shopPresenter;
        private readonly ILoadingScreenPresenter _loadingScreenPresenter;
        private readonly IWallet _wallet;

        public ShopScreenManager(IShopPresenter shopPresenter, ILoadingScreenPresenter loadingScreenPresenter,
            IWallet wallet)
        {
            _shopPresenter = shopPresenter;
            _loadingScreenPresenter = loadingScreenPresenter;
            _wallet = wallet;
        }
        
        public void Initialize()
        {
            _shopPresenter.OnBack += Deactivate;
            _wallet.OnOpenShop += Activate;
        }

        public async void Activate()
        {
            if (_shopPresenter.IsActive == false)
            {
                await _loadingScreenPresenter.ShowView();

                await _shopPresenter.ShowView();
                
                _loadingScreenPresenter.HideView();
            }
        }

        public void Deactivate()
        {
            _shopPresenter.HideView();
        }

        public void Dispose()
        {
            _shopPresenter.OnBack -= Deactivate;
            _wallet.OnOpenShop -= Activate;
        }
    }
}