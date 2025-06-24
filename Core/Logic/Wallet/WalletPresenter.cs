using System;
using Core.Logic.Shop.Interfaces;
using Core.Logic.Wallet.Interfaces;
using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using UnityEngine;
using Zenject;

namespace Core.Logic.Wallet
{
    public class WalletPresenter : IWalletPresenter, IInitializable, IDisposable
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly IWalletService _walletService;
        
        private IWalletView _walletView;

        public WalletPresenter(ICoreScreenManager coreScreenManager, IWalletService walletService)
        {
            _coreScreenManager = coreScreenManager;
            _walletService = walletService;
        }

        public void Initialize()
        {
            _walletService.OnValueChanged += UpdateValue;
        }

        public async void ShowView()
        {
            _walletView = await _coreScreenManager.ShowCoreAsync<IWalletView>(ResourcesProvider.UI.WalletView);

            _walletView.Initialize(OpenShopEvent);
            
            UpdateValue();
        }

        public void HideView()
        {
            if (_walletView != null)
            {
                _walletView.Hide();
            }
        }

        private void UpdateValue()
        {
            if (_walletView != null)
            {
                string currentHardValue = _walletService.CurrentHardValue.ToString();
            
                _walletView.SetValue(currentHardValue);
            }
        }
        
        private void OpenShopEvent()
        {
            _walletService.OpenShop();
        }

        public void Dispose()
        {
            _walletService.OnValueChanged -= UpdateValue;
        }
    }
}