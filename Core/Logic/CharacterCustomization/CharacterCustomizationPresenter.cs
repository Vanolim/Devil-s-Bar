using System;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Managers.CameraController.Interfaces;
using Core.Services.LoadingScreenService.Interfaces;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Core.Logic.CharacterCustomization
{
    public class CharacterCustomizationPresenter : ICharacterCustomizationPresenter, IInitializable, IDisposable
    {
        private readonly ICharacterCustomizationCameraAnimationController _cameraAnimation;
        private readonly ICharacterCustomizationChangePresenter _characterCustomizationChangePresenter;
        private readonly ICharacterCustomizationMenuPresenter _characterCustomizationMenuPresenter;
        private readonly ILoadingScreenPresenter _loadingScreenPresenter;

        private bool _isActive;

        public event Action OnHome;
        
        public CharacterCustomizationPresenter(
            ICharacterCustomizationChangePresenter characterCustomizationChangePresenter, 
            ICharacterCustomizationMenuPresenter characterCustomizationMenuPresenter, 
            ICharacterCustomizationCameraAnimationController cameraAnimation,
            ILoadingScreenPresenter loadingScreenPresenter)
        {
            _characterCustomizationChangePresenter = characterCustomizationChangePresenter;
            _characterCustomizationMenuPresenter = characterCustomizationMenuPresenter;
            _cameraAnimation = cameraAnimation;
            _loadingScreenPresenter = loadingScreenPresenter;
        }
        
        public void Initialize()
        {
            _characterCustomizationMenuPresenter.OnCharacters += TransitToChangePresenter;
            _characterCustomizationMenuPresenter.OnBack += HomeEvent;
            
            _characterCustomizationChangePresenter.OnBack += TransitToMenuPresenter;
            _characterCustomizationChangePresenter.OnHome += HomeEvent;
        }

        public async void ShowView()
        {
            _loadingScreenPresenter.ShowView();
            
            _cameraAnimation.PlayCharacterCustomizationAnimation();
            
            _characterCustomizationChangePresenter.HideView();
            await _characterCustomizationMenuPresenter.ShowView();
            
            _loadingScreenPresenter.HideView();
            
            _isActive = true;
        }
        
        public async UniTask HideViewWithAnimation()
        {
            _cameraAnimation.RevertCharacterCustomizationAnimation();
            
            _isActive = false;
            
            await _characterCustomizationChangePresenter.HideViewWithAnimation();
            await _characterCustomizationMenuPresenter.HideViewWithAnimation();
        }

        public void HideView()
        {
            _cameraAnimation.RevertCharacterCustomizationAnimation();
            _characterCustomizationChangePresenter.HideView();
            _characterCustomizationMenuPresenter.HideView();
            
            _isActive = false;
        }

        private async void TransitToMenuPresenter()
        {
            if (_isActive)
            {
                await _characterCustomizationChangePresenter.HideViewWithTransitToMenuAnimation();
                _characterCustomizationMenuPresenter.ShowViewWithAnimationAfterChange();
            }
        }

        private async void TransitToChangePresenter()
        {
            if (_isActive)
            {
                //todo: add _loadingScreenPresenter logics;
                //_loadingScreenPresenter.ShowView();
                
                await _characterCustomizationMenuPresenter.HideViewWithTransitToChangeAnimation();
                await _characterCustomizationChangePresenter.ShowView();
                
                //_loadingScreenPresenter.HideView();
            }
        }

        private void HomeEvent()
        {
            if (_isActive)
            {
                OnHome?.Invoke();
            }
        }

        public void Dispose()
        {
            _characterCustomizationMenuPresenter.OnCharacters -= TransitToChangePresenter;
            _characterCustomizationMenuPresenter.OnBack -= HomeEvent;
            _characterCustomizationChangePresenter.OnBack -= TransitToMenuPresenter;
            _characterCustomizationChangePresenter.OnHome -= HomeEvent;
        }
    }
}