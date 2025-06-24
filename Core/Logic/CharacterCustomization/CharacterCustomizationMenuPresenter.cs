using System;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization
{
    public class CharacterCustomizationMenuPresenter : ICharacterCustomizationMenuPresenter
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly ICharacterCustomizationService _characterCustomizationService;
        private readonly ICharacterModelPresenter _characterModelPresenter;
        
        private ICharacterCustomizationMenuView _view;

        private bool _isActive;

        public event Action OnBack;
        public event Action OnMenu;
        public event Action OnCharacters;
        public event Action OnSkins;
        public event Action OnWeapons;
        
        public CharacterCustomizationMenuPresenter(ICoreScreenManager coreScreenManager, ICharacterCustomizationService characterCustomizationService, ICharacterModelPresenter characterModelPresenter)
        {
            _coreScreenManager = coreScreenManager;
            _characterCustomizationService = characterCustomizationService;
            _characterModelPresenter = characterModelPresenter;
        }
        
        public async UniTask ShowView()
        {
            _view = await _coreScreenManager
                .ShowCoreAsync<ICharacterCustomizationMenuView>(ResourcesProvider.UI.CharacterCustomizationMenuView);
            
            _view.Initialize(BackEvent, MenuEvent, CharactersEvent, SkinsEvent, WeaponsEvent);
            
            var currentCharacterData = _characterCustomizationService.GetCurrentCharacterData();
            _view.SetCharacterInfo(currentCharacterData.CharacterName, currentCharacterData.CharacterDescription);
            
            _characterModelPresenter.ShowCurrentCharacterWithCharacterBackground();
            
            _isActive = true;
        }

        public async UniTask ShowViewWithAnimationAfterChange()
        {
            _view = await _coreScreenManager
                .ShowCoreAsync<ICharacterCustomizationMenuView>(ResourcesProvider.UI.CharacterCustomizationMenuView);
            
            _view.Initialize(OnBack, OnMenu, OnCharacters, OnSkins, OnWeapons);
            _view.ShowAfterChange();
            
            var currentCharacterData = _characterCustomizationService.GetCurrentCharacterData();
            _view.SetCharacterInfo(currentCharacterData.CharacterName, currentCharacterData.CharacterDescription);
            
            _characterModelPresenter.ShowCurrentCharacterWithCharacterBackground();
            
            _isActive = true;
        }

        public async UniTask HideViewWithTransitToChangeAnimation()
        {
            _isActive = false;
            
            if (_view != null)
            {
                await _view.HideViewWithTransitToChangeAnimation();
            }
        }
        
        public async UniTask HideViewWithAnimation()
        {
            _isActive = false;
            
            if (_view != null)
            {
                await _view.HideWithAnimation();
            }
        }
        
        public void HideView()
        {
            _isActive = false;
            
            if (_view != null)
            {
                _view.Hide();
            }
        }

        private void BackEvent()
        {
            if (_isActive)
            {
                OnBack?.Invoke();
            }
        }

        private void MenuEvent()
        {
            if (_isActive)
            {
                OnMenu?.Invoke();
            }
        }

        private void CharactersEvent()
        {
            if (_isActive)
            {
                OnCharacters?.Invoke();
            }
        }

        private void SkinsEvent()
        {
            if (_isActive)
            {
                OnSkins?.Invoke();
            }
        }

        private void WeaponsEvent()
        {
            if (_isActive)
            {
                OnWeapons?.Invoke();
            }
        }
    }
}