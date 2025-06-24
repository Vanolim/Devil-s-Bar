using System;

namespace Core.Managers.ScreenManager
{
    public interface IBaseScreen
    {
        event Action<IBaseScreen> OnDestroyed;
        void Show();
        void Hide();
    }
}