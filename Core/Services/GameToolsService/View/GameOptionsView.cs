using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.View
{
    public class GameOptionsView : MonoBehaviour
    {
        [SerializeField] private Toggle _simpleGame;
        
        public event Action<bool> OnSimpleGameChanged;

        public void SetDefaultSimpleGameValue(bool value)
        {
            _simpleGame.isOn = value;
        }
        
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);

        private void OnEnable()
        {
            _simpleGame.onValueChanged.AddListener((value) => OnSimpleGameChanged?.Invoke(value));
        }

        private void OnDisable()
        {
            _simpleGame.onValueChanged.RemoveAllListeners();
        }
    }
}