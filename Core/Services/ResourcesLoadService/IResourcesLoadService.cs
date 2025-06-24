using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Services.ResourcesLoadService
{
    public interface IResourcesLoadService
    {
        UniTask<T> LoadAsync<T>(string key, ILifeTime lifeTime);
        UniTask<T> LoadWithComponentAsync<T>(string key, ILifeTime lifetime) where T : Component;
        UniTask<T> LoadAndReleaseAsync<T>(string key);
    }
}