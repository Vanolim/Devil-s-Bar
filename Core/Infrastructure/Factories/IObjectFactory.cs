using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Infrastructure.Factories
{
    public interface IObjectFactory
    {
        public bool IsObjectCreating(string objectKey, out object existingTask);
        public UniTask<T> GetAsync<T>(string objectKey, ILifeTime lifeTime, Transform parent);
    }
}