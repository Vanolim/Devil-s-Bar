using System.Collections.Generic;
using Core.Services.ResourcesLoadService;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure.Factories
{
    public class ObjectFactory : IObjectFactory
    {
        private readonly IResourcesLoadService _resourcesLoadService;
        private readonly IInstantiator _instantiator;
        
        private readonly Dictionary<string, object> _creatingObjects = new();
        
        public ObjectFactory(IResourcesLoadService resourcesLoadService, IInstantiator instantiator)
        {
            _resourcesLoadService = resourcesLoadService;
            _instantiator = instantiator;
        }

        public bool IsObjectCreating(string objectKey, out object creatingTask)
        {
            bool isCreating = _creatingObjects.TryGetValue(objectKey, out var existingTask);
            creatingTask = existingTask;
            return isCreating;
        }

        public async UniTask<T> GetAsync<T>(string objectKey, ILifeTime lifeTime, Transform parent)
        {
            var createPrefabTask = InstanceObject<T>(objectKey, lifeTime, parent).ToAsyncLazy();
            _creatingObjects.Add(objectKey, createPrefabTask);
                
            try
            {
                var instance = await createPrefabTask;
                return instance;
            }
            finally
            {
                _creatingObjects.Remove(objectKey);
            }
        }

        private async UniTask<T> InstanceObject<T>(string objectKey, ILifeTime lifeTime, Transform parent)
        {
            var createPrefabTask = await _resourcesLoadService.LoadAsync<GameObject>(objectKey, lifeTime).ToAsyncLazy();
            var instance = _instantiator.InstantiatePrefab(createPrefabTask, parent).GetComponent<T>();

            return instance;
        }
    }
}