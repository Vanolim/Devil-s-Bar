using System;
using Core.Logic.CharacterCustomization.Data;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization
{
    public class CharacterCustomizationChangePresenter : ICharacterCustomizationChangePresenter
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly ICharacterModelPresenter _characterModelPresenter;
        private readonly ICharacterCustomizationService _characterCustomizationService;
        
        private ICharacterCustomizationChangeView _view;
        private ICharacterCustomizationSlotView[] _charactersSlot;

        private ICharacterCustomizationSlotView _selectedSlot;
        
        private bool _isActive;
        
        public event Action OnBack;
        public event Action OnHome;

        public CharacterCustomizationChangePresenter(ICoreScreenManager coreScreenManager, ICharacterModelPresenter characterModelPresenter, ICharacterCustomizationService characterCustomizationService)
        {
            _coreScreenManager = coreScreenManager;
            _characterModelPresenter = characterModelPresenter;
            _characterCustomizationService = characterCustomizationService;
        }
        
        public async UniTask ShowView()
        {
            _view = await _coreScreenManager
                .ShowCoreAsync<ICharacterCustomizationChangeView>(ResourcesProvider.UI.CharacterCustomizationChangeView);

            _charactersSlot = await _characterCustomizationService.GetCharactersSlot();
            InitializeCharactersSlot();

            var currentCharacterData =_characterCustomizationService.GetCurrentCharacterData();
            _view.SetCurrentCharacterInfo(currentCharacterData.CharacterName, currentCharacterData.CharacterDescription);
            
            _view.SetCharacters(_charactersSlot);
            
            _view.Initialize(BackEvent, HomeEvent, ShowRandomCharacterInfo, ChangeRandomCharacterValue);

            _isActive = true;
        }

        public async UniTask HideViewWithTransitToMenuAnimation()
        {
            _isActive = false;
            
            if (_view != null)
            {
                await _view.HideViewWithTransitToMenuAnimation();
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

        private void InitializeCharactersSlot()
        {
            _selectedSlot = _characterCustomizationService.GetSelectedSlot();
            
            foreach (var characterSlot in _charactersSlot)
            {
                characterSlot.Initialize(CharacterSelectSlotHandler);
            }
        }

        private void CharacterSelectSlotHandler(ICharacterCustomizationSlotView selectedSlot)
        {
            if (_isActive == false)
            {
                return;
            }
            
            CharacterCustomizationData characterCustomizationData = _characterCustomizationService.GetCharacterCustomizationData(selectedSlot);
            _characterModelPresenter.ShowCharacterWithCharacterBackground(characterCustomizationData.CharacterId);
            
            if (characterCustomizationData.IsLock == false)
            {
                _selectedSlot.SetSelected(false);
                
                _selectedSlot = selectedSlot;
                _selectedSlot.SetSelected(true);
                
                _characterCustomizationService.SetSelectedCharacter(characterCustomizationData.CharacterId);
            }

            _view.SetCurrentCharacterInfo(characterCustomizationData.CharacterName, characterCustomizationData.CharacterDescription);
        }

        private void ShowRandomCharacterInfo()
        {
            //TODO: Add info
        }

        private void ChangeRandomCharacterValue(bool value)
        {
            //TODO: Add random
        }

        private void BackEvent()
        {
            if (_isActive)
            {
                OnBack?.Invoke();
            }
        }

        private void HomeEvent()
        {
            if (_isActive)
            {
                OnHome?.Invoke();
            }
        }
    }
}