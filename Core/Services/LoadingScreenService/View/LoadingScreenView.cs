using System;
using Core.Managers.ScreenManager;
using Core.Services.LoadingScreenService.Interfaces;
using TMPro;
using UnityEngine;

namespace Core.Services.LoadingScreenService.View
{
    public class LoadingScreenView : MonoBehaviour, ILoadingScreenView
    {
        [SerializeField]
        private TMP_Text _loadingText;
        
        public event Action<IBaseScreen> OnDestroyed;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetLoadingText(string value)
        {
            _loadingText.text = value;
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}