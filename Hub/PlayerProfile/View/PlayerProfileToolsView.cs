using System;
using Hub.PlayerProfile.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Hub.PlayerProfile.View
{
    public class PlayerProfileToolsView : MonoBehaviour, IPlayerProfileToolsView
    {
        [SerializeField] 
        private Button _copyName;
        
        [SerializeField] 
        private Button _changeName;
        
        private event Action _onCopyButtonEvent;
        private event Action _onChangeButtonEvent;
        
        private void OnEnable()
        {
            _copyName.onClick.AddListener(() => _onCopyButtonEvent?.Invoke());
            _changeName.onClick.AddListener(() => _onChangeButtonEvent?.Invoke());
        }

        public void Initialize(Action copyButtonEvent, Action changeButtonEvent)
        {
            _onCopyButtonEvent = copyButtonEvent;
            _onChangeButtonEvent = changeButtonEvent;
        }

        private void OnDisable()
        {
            _copyName.onClick.RemoveAllListeners();
            _changeName.onClick.RemoveAllListeners();
        }
    }
}