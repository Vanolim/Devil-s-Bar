using System;
using Core.Managers.ScreenManager;
using Core.Services.TimerService.Interfaces;
using TMPro;
using UnityEngine;

namespace Core.Services.TimerService.View
{
    public class TimerServiceView : MonoBehaviour, ITimerServiceView
    {
        [SerializeField] 
        private TMP_Text _timer;

        public event Action<IBaseScreen> OnDestroyed;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetTimer(string value)
        {
            _timer.text = value;
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