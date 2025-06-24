using Core.Managers.ScreenManager;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameInfoView : IBaseScreen
    {
        bool IsShow { get; }
        void SetPlayerInfo(string name, string id, string skin, int playerIndex);
        void SetRegion(string region);
        void SetRoomInfo(string name, bool isOpen, bool isVisible);
        void SetGameVersion(string gameVersion);
        void SetDefaultValue();
    }
}