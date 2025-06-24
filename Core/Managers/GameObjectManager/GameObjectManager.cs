using System.Collections.Generic;
using System.Linq;
using Core.Infrastructure.Factories;
using Core.Infrastructure.ObjectProvider;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Managers.GameObjectManager
{
    public class GameObjectManager : BaseManager, IGameObjectManager, ICoreGameObjectManger, ISceneGameObjectManager
    {
        private readonly Dictionary<string, IBaseGameObject> _activeObjects = new();

        public GameObjectManager(IObjectFactory objectFactory, ICoreObjectProvider coreObjectProvider, ISceneObjectProvider sceneObjectProvider) : base(objectFactory, coreObjectProvider, sceneObjectProvider)
        {
        }

        public async UniTask<T> GetObjectAsync<T>(string objectKey) where T : IBaseGameObject
        {
            ILifeTime lifeTime = SceneLifeTimeHolder.SceneLifeTime;
            Transform parent = SceneObjectProvider.GetSceneObjectContainer();
            
            return await GetObjectAsync<T>(objectKey, lifeTime, parent);
        }

        public async UniTask<T> GetCoreObjectAsync<T>(string objectKey) where T : IBaseGameObject
        {
            ILifeTime lifeTime = SceneLifeTimeHolder.ProjectLifeTime;
            Transform parent = CoreObjectProvider.GetObjectContainer();
            
            return await GetObjectAsync<T>(objectKey, lifeTime, parent);
        }

        private async UniTask<T> GetObjectAsync<T>(string objectKey, ILifeTime lifeTime, Transform parent) where T : IBaseGameObject
        {
            var instance = await GetAsync<T>(objectKey, lifeTime, parent);

            if (_activeObjects.ContainsKey(objectKey) == false)
            {
                _activeObjects.Add(objectKey, instance);
            }

            instance.OnDestroyed += RemoveDestroyedScreen;
            
            return instance;
        }

        protected override bool IsAlreadyHasTargetObject<T>(string targetObjectKey, out T targetObject)
        {
            if (_activeObjects.ContainsKey(targetObjectKey))
            {
                targetObject = (T)_activeObjects[targetObjectKey];
                return true;
            }

            targetObject = default;
            return false;
        }
        
        private void RemoveDestroyedScreen(IBaseGameObject baseScreen)
        {
            foreach (var activeScreen in _activeObjects.ToList())
            {
                if (activeScreen.Value == baseScreen)
                {
                    activeScreen.Value.OnDestroyed -= RemoveDestroyedScreen;
                    _activeObjects.Remove(activeScreen.Key);
                }
            }
        }
    }
}