using Core.Infrastructure.Factories;
using Core.Infrastructure.ObjectProvider;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Managers
{
    public abstract class BaseManager
    {
        private readonly IObjectFactory _objectFactory;
        private readonly ICoreObjectProvider _coreObjectProvider;
        private readonly ISceneObjectProvider _sceneObjectProvider;
        
        protected ICoreObjectProvider CoreObjectProvider => _coreObjectProvider;
        protected ISceneObjectProvider SceneObjectProvider => _sceneObjectProvider;
        
        protected BaseManager(IObjectFactory objectFactory, ICoreObjectProvider coreObjectProvider, ISceneObjectProvider sceneObjectProvider)
        {
            _objectFactory = objectFactory;
            _coreObjectProvider = coreObjectProvider;
            _sceneObjectProvider = sceneObjectProvider;
        }
        
        protected async UniTask<T> GetAsync<T>(string objectKey, ILifeTime lifeTime, Transform parent)
        {
            if (IsAlreadyHasTargetObject(objectKey, out T targetObject))
            {
                return targetObject;
            }
            
            if (_objectFactory.IsObjectCreating(objectKey, out object existingTask))
            {
                return (await (AsyncLazy<T>)existingTask);
            }

            return await CreateAsync<T>(objectKey, lifeTime, parent).ToAsyncLazy();
        }
        
        protected abstract bool IsAlreadyHasTargetObject<T>(string targetObjectKey, out T targetScreen);

        private async UniTask<T> CreateAsync<T>(string objectKey, ILifeTime lifeTime, Transform parent)
        {
            var targetObject = await _objectFactory.GetAsync<T>(objectKey, lifeTime, parent);
            return targetObject;
        }
    }
}