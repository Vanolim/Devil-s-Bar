using Core.Managers.ScreenManager;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IPlayerManualProfileView : IBaseScreen
    {
        IPlayerProfileView PlayerProfileView { get; }
        IPlayerProfileToolsView PlayerProfileToolsView { get; }

        void Hide();
    }
}