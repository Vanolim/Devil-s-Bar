using System;
using Core.Logic.CharacterModelDisplayer.Infrastructure;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;
using Hub.HubMenu.Interfaces;

namespace Hub.HubMenu
{
    public class HubMenuPresenter : IHubMenuPresenter
    {
        private readonly ICharacterModelPresenter _characterModelPresenter;
        private readonly ISceneScreenManager _sceneScreenManager;
        
        private IHubMenuView _hubMenuView;

        public event Action OnPlay;
        public event Action OnСustomize;
        public event Action OnSettings;
        public event Action OnShop;
        public event Action OnOptions;

        public HubMenuPresenter(ICharacterModelPresenter characterModelPresenter, ISceneScreenManager sceneScreenManager)
        {
            _characterModelPresenter = characterModelPresenter;
            _sceneScreenManager = sceneScreenManager;
        }

        public async UniTask ShowView()
        {
            _hubMenuView = await _sceneScreenManager.ShowAsync<IHubMenuView>(ResourcesProvider.UI.HubMenuView);
            
            _hubMenuView.Initialize(СustomizeEvent, SettingsEvent, ShopEvent, OptionsEvent, PlayEvent);

            await _characterModelPresenter.ShowCurrentCharacterWithCharacterBackground();
        }

        public void HideView()
        {
            if (_hubMenuView != null)
            {
                _hubMenuView.Hide();
            }
        }

        public UniTask HideMenuWithAnimation()
        {
            if (_hubMenuView != null)
            {
                return _hubMenuView.HideWithAnimation();
            }

            return UniTask.CompletedTask;
        }

        private void PlayEvent() => OnPlay?.Invoke();

        private void СustomizeEvent() => OnСustomize?.Invoke();
        private void SettingsEvent() => OnSettings?.Invoke();
        private void ShopEvent() => OnShop?.Invoke();
        private void OptionsEvent() => OnOptions?.Invoke();
    }
}