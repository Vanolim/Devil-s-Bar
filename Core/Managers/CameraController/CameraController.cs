using Core.Infrastructure.ObjectProvider;
using Core.Managers.CameraController.Interfaces;
using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Core.Managers.CameraController
{
    public class CameraController : ICharacterCustomizationCameraAnimationController, IInitializable
    {
        private readonly ISceneObjectProvider _sceneObjectProvider;
        private readonly ICameraAnimationDataProvider _cameraAnimationDataProvider;
        
        private CinemachineCamera _animationCamera;
        private AnimationState _currentAnimationState;
        private Tween _currentAnimation;
        private Vector3 _initAnimationCameraPosition;
        
        public CameraController(ISceneObjectProvider sceneObjectProvider, ICameraAnimationDataProvider cameraAnimationDataProvider)
        {
            _sceneObjectProvider = sceneObjectProvider;
            _cameraAnimationDataProvider = cameraAnimationDataProvider;
        }
        
        public void Initialize()
        {
            _currentAnimationState = AnimationState.Idle;
        }

        public void PlayCharacterCustomizationAnimation()
        {
            if (_currentAnimationState == AnimationState.Idle || _currentAnimationState == AnimationState.PlayingRevertCharacterCustomizationAnimation)
            {
                SetAnimationCamera();
                
                var animationData = _cameraAnimationDataProvider.GetCharacterCustomizationCameraAnimationData();

                var animationMoveTarget = _initAnimationCameraPosition + animationData.TargetMove;

                _currentAnimation = _animationCamera.transform
                    .DOMove(animationMoveTarget, animationData.CameraAnimationDuration)
                    .SetEase(animationData.MovementEase)
                    .OnComplete(() => _currentAnimationState = AnimationState.CharacterCustomization);

                _currentAnimation.Play();

                _currentAnimationState = AnimationState.PlayingCharacterCustomizationAnimation;
            }
        }

        public void RevertCharacterCustomizationAnimation()
        {
            if (_currentAnimationState == AnimationState.PlayingCharacterCustomizationAnimation || _currentAnimationState == AnimationState.CharacterCustomization)
            {
                SetAnimationCamera();

                if (_currentAnimation != null)
                {
                    _currentAnimation.Kill();
                }
                
                var animationData = _cameraAnimationDataProvider.GetCharacterCustomizationCameraAnimationData();

                _currentAnimation = _animationCamera.transform
                    .DOMove(_initAnimationCameraPosition, animationData.CameraAnimationDuration)
                    .SetEase(animationData.MovementEase)
                    .OnComplete(() => _currentAnimationState = AnimationState.Idle);

                _currentAnimation.Play();

                _currentAnimationState = AnimationState.PlayingRevertCharacterCustomizationAnimation;
            }
        }

        private void SetAnimationCamera()
        {
            var camera = _sceneObjectProvider.GetAnimationCamera();
            
            if (_animationCamera == null || _animationCamera != camera)
            {
                _animationCamera = camera;
                _initAnimationCameraPosition = camera.transform.position;
            }
        }
        
        private enum AnimationState
        {
            Idle, 
            PlayingCharacterCustomizationAnimation, 
            CharacterCustomization,
            PlayingRevertCharacterCustomizationAnimation
        }
    }
}