using Core.Managers.ScreenManager;

namespace Core.Services.LoadingScreenService.Interfaces
{
    public interface ILoadingScreenView : IBaseScreen
    {
        void SetLoadingText(string value);
    }
}