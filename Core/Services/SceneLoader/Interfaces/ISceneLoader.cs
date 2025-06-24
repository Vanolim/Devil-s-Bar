using Cysharp.Threading.Tasks;

namespace Core.Services.SceneLoader.Interfaces
{
    public interface ISceneLoader
    {
        UniTask LoadAsync(string sceneKey);
    }
}