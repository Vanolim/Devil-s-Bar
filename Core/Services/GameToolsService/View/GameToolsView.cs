using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.View
{
    public class GameToolsView : MonoBehaviour, IGameToolsView
    {
        [SerializeField] 
        private Button _showGameTools;
        
        public event Action<IBaseScreen> OnDestroyed;
        public event Action OnShowGameToolsMenu;

        private void OnEnable()
        {
            _showGameTools.onClick.AddListener(() => OnShowGameToolsMenu?.Invoke());
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
            _showGameTools.onClick.RemoveAllListeners();
        }
    }
}