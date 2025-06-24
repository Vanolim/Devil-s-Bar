using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.View
{
    public class GameToolsMenuView : MonoBehaviour, IBaseScreen, IGameToolsMenuView
    {
        [SerializeField] private Button _showDebug;
        [SerializeField] private Button _showGameInfo;
        [SerializeField] private Button _pauseGame;
        [SerializeField] private Button _showSelectTargetView;
        [SerializeField] private Button _showSelectCardView;
        [SerializeField] private Button _showGameOptionsView;
        [SerializeField] private Button _hide;
        private event Action _onShowDebug;
        private event Action _onShowGameInfo;
        private event Action _onHide;
        
        public event Action<IBaseScreen> OnDestroyed;

        private void OnEnable()
        {
            _showDebug.onClick.AddListener(() => _onShowDebug?.Invoke());
            _showGameInfo.onClick.AddListener(() => _onShowGameInfo?.Invoke());
            _hide.onClick.AddListener(() => _onHide?.Invoke());
        }
        
        public void Initialize(Action showDebug, Action showInfo, Action hide)
        {
            _onShowDebug = showDebug;
            _onShowGameInfo = showInfo;
            _onHide = hide;
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
            _showDebug.onClick.RemoveAllListeners();
            _showGameInfo.onClick.RemoveAllListeners();
            _showSelectTargetView.onClick.RemoveAllListeners();
            _showSelectCardView.onClick.RemoveAllListeners();
            _showGameOptionsView.onClick.RemoveAllListeners();
            _pauseGame.onClick.RemoveAllListeners();
            _hide.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}