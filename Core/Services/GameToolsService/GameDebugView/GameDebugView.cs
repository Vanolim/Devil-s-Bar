using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.GameDebugView
{
    public class GameDebugView : MonoBehaviour, IGameDebugView
    {
        [SerializeField] 
        private TMP_Text _textArea;

        [SerializeField]
        private Button _copy;
        
        public event Action<IBaseScreen> OnDestroyed;
        public event Action OnCopy;

        public bool IsShow { get; private set; }

        private void OnEnable()
        {
            _copy.onClick.AddListener(() => OnCopy?.Invoke());
        }

        public void Show()
        {
            gameObject.SetActive(true);
            IsShow = true;
        }        
        
        public void SetText(string value)
        {
            _textArea.text = value;
        }

        public void Clear()
        {
            _textArea.text = "";
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            IsShow = false;
        }

        private void OnDisable()
        {
            _copy.onClick.RemoveAllListeners();
        }
        
        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}