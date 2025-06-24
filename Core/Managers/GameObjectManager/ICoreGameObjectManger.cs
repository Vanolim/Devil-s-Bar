using Cysharp.Threading.Tasks;

namespace Core.Managers.GameObjectManager
{
    public interface ICoreGameObjectManger
    {
        public UniTask<T> GetCoreObjectAsync<T>(string objectKey) where T : IBaseGameObject;
    }
}