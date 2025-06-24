using System.Collections.Generic;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.TickableService
{
    public class TickableService : ITickableService, IManualTickableService
    {
        private readonly List<ITickable> _tickables = new();

        private bool _isPaused;
        private ILifeTime _lifeTime;

        public void Start(ILifeTime lifeTime)
        {
            if (_lifeTime != null)
            {
                //_lifeTime.Dispose();
            }
            
            _lifeTime = lifeTime;
            
            UpdateLoop().Forget();
        }

        public void Pause()
        {
            _isPaused = true;
        }
        
        public void UnPause()
        {
            _isPaused = false;
        }

        public void Stop()
        {
            if (_lifeTime != null)
            {
                //_lifeTime.Dispose();
            }
        }

        public void Add(ITickable value)
        {
            _tickables.Add(value);
        }

        public void Remove(ITickable value)
        {
            _tickables.Remove(value);
        }
        
        private async UniTaskVoid UpdateLoop()
        {
            while (_lifeTime.IsOngoing)
            {
                await UniTask.WaitWhile(() => _isPaused);
                
                UpdateTickables();
                await UniTask.Yield();
            }
        }

        private void UpdateTickables()
        {
            if (_tickables.Count > 0)
            {
                for (int i = 0; i < _tickables.Count; i++)
                {
                    _tickables[i].Tick(Time.deltaTime);
                }
            }
        }
    }
}