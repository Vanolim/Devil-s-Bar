using Cysharp.Threading.Tasks;

namespace Core.Managers.ScreenManager
{
    public interface ISceneScreenManager
    {
        public UniTask<T> ShowAsync<T>(string screenKey, bool show = true) where T : IBaseScreen;
    }
}