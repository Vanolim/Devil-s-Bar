using Cysharp.Threading.Tasks;

namespace Core.Managers.ScreenManager
{
    public interface ICoreScreenManager
    {
        public UniTask<T> ShowCoreAsync<T>(string screenKey, bool show = true) where T : IBaseScreen;
    }
}