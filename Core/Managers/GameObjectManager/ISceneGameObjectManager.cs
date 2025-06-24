using Cysharp.Threading.Tasks;

namespace Core.Managers.GameObjectManager
{
    public interface ISceneGameObjectManager
    {
        public UniTask<T> GetObjectAsync<T>(string objectKey) where T : IBaseGameObject;
    }
}