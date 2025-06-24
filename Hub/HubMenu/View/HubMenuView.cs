using System;
using Core.Logic.View.UIAnimatorController;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;
using Hub.HubMenu.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Hub.HubMenu.View
{
    public class HubMenuView : MonoBehaviour, IHubMenuView
    {
        [SerializeField]
        private Button _customize;
        
        [SerializeField]
        private Button _play;
        
        [SerializeField] 
        private Button _settings;
        
        [SerializeField] 
        private Button _shop;
        
        [SerializeField] 
        private Button _options;

        [SerializeField]
        private AnimatorUIController _animatorUIController;

        private event Action _onCustomizeButtonEvent;
        private event Action _onSettingsButtonEvent;
        private event Action _onShopButtonEvent;
        private event Action _onOptionsButtonEvent;
        private event Action _onPlayButtonEvent;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _customize.onClick.AddListener(() => _onCustomizeButtonEvent?.Invoke());
            _play.onClick.AddListener(() => _onPlayButtonEvent?.Invoke());
            _shop.onClick.AddListener(() => _onShopButtonEvent?.Invoke());
            
            // _settings.onClick.AddListener(() => _onSettingsButtonEvent?.Invoke());
            // _options.onClick.AddListener(() => _onOptionsButtonEvent?.Invoke());
        }

        public void Initialize(Action customizeButtonEvent, Action settingsButtonEvent,
            Action shopButtonEvent, Action optionsButtonEvent, Action playButtonEvent)
        {
            _onCustomizeButtonEvent = customizeButtonEvent;
            _onSettingsButtonEvent = settingsButtonEvent;
            _onShopButtonEvent = shopButtonEvent;
            _onOptionsButtonEvent = optionsButtonEvent;
            _onPlayButtonEvent = playButtonEvent;
        }

        public async UniTask HideWithAnimation()
        {
            if (gameObject.activeSelf)
            {
                await _animatorUIController.PlayHideAnimation();
                Hide();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _customize.onClick.RemoveAllListeners();
            _play.onClick.RemoveAllListeners();
            _shop.onClick.RemoveAllListeners();
            
            // _settings.onClick.RemoveAllListeners();
            // _options.onClick.RemoveAllListeners();
        }
        
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}