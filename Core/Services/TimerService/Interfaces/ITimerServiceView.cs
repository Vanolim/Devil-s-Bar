using Core.Managers.ScreenManager;

namespace Core.Services.TimerService.Interfaces
{
    public interface ITimerServiceView : IBaseScreen
    {
        void SetTimer(string value);
        void Hide();
    }
}