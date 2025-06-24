using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.ResourcesLoadService.LifeTime
{
    public class LifeTime : ILifeTime, IDisposable
    {
        public bool IsOngoing => !isDisposed;

        public CancellationToken CancellationToken => _cts.Token;
        
        private bool isDisposed = false;
        private CancellationTokenSource _cts = new CancellationTokenSource();
        
        public async UniTask WaitForEnd() => await UniTask.WaitUntil(() => !IsOngoing, PlayerLoopTiming.PreUpdate);

        public void Dispose()
        {
            if (isDisposed)
            {
                return;
            }

            _cts?.Cancel();
            _cts?.Dispose();

            isDisposed = true;
        }
    }
}