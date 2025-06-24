using System;
using Core.Managers.ScreenManager;
using Hub.PlayerProfile.Interfaces;
using UnityEngine;

namespace Hub.PlayerProfile.View
{
    public class PlayerManualProfileView : MonoBehaviour, IPlayerManualProfileView
    {
        [SerializeField] 
        private PlayerProfileView _playerProfileView;
        
        [SerializeField] 
        private PlayerProfileToolsView _playerProfileToolsView;
        
        public event Action<IBaseScreen> OnDestroyed;
        
        public IPlayerProfileView PlayerProfileView => _playerProfileView;
        public IPlayerProfileToolsView PlayerProfileToolsView => _playerProfileToolsView;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}