using System;
using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Core.Services.TickableService;
using Core.Services.TimerService.Interfaces;
using UnityEngine;
using Zenject;
using ITickable = Core.Services.TickableService.ITickable;

namespace Core.Services.TimerService
{
    public class TimerService : ITimerService, ITickable
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly ITickableService _tickableService;
        
        private ITimerServiceView _timerServiceView;
        
        private float _timer;
        private Action _completedCallback;
        
        public bool IsPlaying { get; private set; }
        
        public TimerService(ICoreScreenManager coreScreenManager, ITickableService tickableService)
        {
            _coreScreenManager = coreScreenManager;
            _tickableService = tickableService;
            IsPlaying = false;
        }

        public async void Start(float value, Action completed)
        {
            Stop();

            _timerServiceView = await _coreScreenManager.ShowCoreAsync<ITimerServiceView>(ResourcesProvider.UI.TimerView);
            
            _timer = value;
            _tickableService.Add(this);
            _completedCallback = completed;
            IsPlaying = true;
        }

        public void Stop()
        {
            _completedCallback = null;
            _tickableService.Remove(this);
            
            if (_timerServiceView != null)
            {
                _timerServiceView.Hide();
            }
            
            IsPlaying = false;
        }

        public void Tick(float dt)
        {
            _timer -= dt;
            if (_timer <= 0)
            {
                _completedCallback?.Invoke();
                Stop();
                return;
            }
            
            _timerServiceView.SetTimer(_timer.ToString("F0"));
        }
    }
}