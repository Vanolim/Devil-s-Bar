using System;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Logic.Shop.Interfaces;
using Core.Logic.Wallet.Interfaces;
using Core.Services.LoadingScreenService.Interfaces;
using Hub.HubMenu.Interfaces;
using Hub.PlayerProfile.Interfaces;
using UnityEngine;
using Zenject;

namespace Hub.HubScreenManager
{
    public class HubScreenManager : IHubScreenManager, IInitializable, IDisposable
    {
        private readonly IHubMenuPresenter _hubMenuPresenter;
        private readonly ICharacterCustomizationPresenter _characterCustomizationPresenter;
        private readonly IPlayerProfilePresenter _playerProfilePresenter;
        private readonly ILoadingScreenPresenter _loadingScreenPresenter;
        private readonly ICharacterModelPresenter _characterModelPresenter;
        private readonly IWalletPresenter _walletPresenter;
        private readonly IShopScreenManager _shopScreenManager;

        public event Action OnPlay;

        public HubScreenManager(
            IHubMenuPresenter hubMenuPresenter,
            ICharacterCustomizationPresenter characterCustomizationPresenter,
            IPlayerProfilePresenter playerProfilePresenter,
            ILoadingScreenPresenter loadingScreenPresenter,
            ICharacterModelPresenter characterModelPresenter,
            IWalletPresenter walletPresenter,
            IShopScreenManager shopScreenManager)
        {
            _hubMenuPresenter = hubMenuPresenter;
            _characterCustomizationPresenter = characterCustomizationPresenter;
            _playerProfilePresenter = playerProfilePresenter;
            _loadingScreenPresenter = loadingScreenPresenter;
            _characterModelPresenter = characterModelPresenter;
            _walletPresenter = walletPresenter;
            _shopScreenManager = shopScreenManager;
        }
        
        public void Initialize()
        {
            _hubMenuPresenter.OnСustomize += OpenCharacterCastomizationView;
            _hubMenuPresenter.OnShop += OpenShop;
            _hubMenuPresenter.OnPlay += PlayEvent;
        }

        public async void Activate()
        {
            await _hubMenuPresenter.ShowView();
            _walletPresenter.ShowView();

            _playerProfilePresenter.ShowView();

            _loadingScreenPresenter.HideView();

            _characterModelPresenter.SetRenderCamera(Camera.main);
        }

        public void Deactivate()
        {
            _hubMenuPresenter.HideView();
            _playerProfilePresenter.HideView();
            _characterModelPresenter.Hide();
        }

        private async void OpenCharacterCastomizationView()
        {
            _playerProfilePresenter.HideView();
            await _hubMenuPresenter.HideMenuWithAnimation();

            _characterCustomizationPresenter.OnHome += HideCharacterCastomizationView;
            _characterCustomizationPresenter.ShowView();
        }

        private async void HideCharacterCastomizationView()
        {
            _characterCustomizationPresenter.OnHome -= HideCharacterCastomizationView;

            await _characterCustomizationPresenter.HideViewWithAnimation();

            _playerProfilePresenter.ShowView();
            _hubMenuPresenter.ShowView();
        }

        private void OpenShop()
        {
            _shopScreenManager.Activate();
        }

        private void PlayEvent() => OnPlay?.Invoke();

        public void Dispose()
        {
            _hubMenuPresenter.OnСustomize -= OpenCharacterCastomizationView;
            _hubMenuPresenter.OnPlay -= PlayEvent;
            _hubMenuPresenter.OnShop -= OpenShop;
        }
    }
}