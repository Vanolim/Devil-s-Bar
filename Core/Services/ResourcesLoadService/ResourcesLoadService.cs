using System;
using System.Collections.Generic;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Core.Services.ResourcesLoadService
{
    public class ResourcesLoadService : IResourcesLoadService
    {
        private readonly Dictionary<ILifeTime, List<AsyncOperationHandle>> _handles = new();
        
        public async UniTask<T> LoadAsync<T>(string key, ILifeTime lifeTime)
        {
            var handle = Addressables.LoadAssetAsync<T>(key);
            return await Load(lifeTime, handle);
        }
        
        public async UniTask<T> LoadWithComponentAsync<T>(string key, ILifeTime lifetime) where T : Component
        {
            var go = await LoadAsync<GameObject>(key, lifetime);
            if (!go.TryGetComponent<T>(out var component))
            {
                throw new NullReferenceException($"Can't get {typeof(T).Name} from {go.name}");
            }

            return component;
        }

        public async UniTask<T> LoadAndReleaseAsync<T>(string key)
        {
            var handle = Addressables.LoadAssetAsync<T>(key);
            var lifeTime = new LifeTime.LifeTime();
            StoreHandleAsync(lifeTime, handle);
            var result = await handle.ToUniTask();
            lifeTime.Dispose();
            return result;
        }

        private async UniTask<T> Load<T>(ILifeTime lifeTime, AsyncOperationHandle<T> handle)
        {
            StoreHandleAsync(lifeTime, handle);
            return await handle.ToUniTask();
        }

        private void StoreHandleAsync<T>(ILifeTime lifeTime, AsyncOperationHandle<T> handle)
        {
            if (lifeTime == null)
            {
                Debug.LogError("[Resources] Lifetime is NULL");
                
                return;
            }
            
            if (!_handles.ContainsKey(lifeTime))
            {
                RemoveHandlesOnLifetimeEnd(lifeTime).Forget();
            }
            
            if(_handles.TryGetValue(lifeTime, out var handles))
            {
                handles.Add(handle);
            }
            else
            {
                _handles.Add(lifeTime, new List<AsyncOperationHandle>{handle});
            }
        }

        private async UniTaskVoid RemoveHandlesOnLifetimeEnd(ILifeTime lifeTime)
        {
            await lifeTime.WaitForEnd();
            RemoveHandlesForLifetime(lifeTime);
        }

        private void RemoveHandlesForLifetime(ILifeTime lifeTime)
        {
            foreach (var handle in _handles[lifeTime])
            {
                if (handle.IsValid())
                {
                    Addressables.Release(handle);
                }
            }

            _handles.Remove(lifeTime);
        }
    }
}