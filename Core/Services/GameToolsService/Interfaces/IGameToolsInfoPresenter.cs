using Core.Data.LobbyPlayerData;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsInfoPresenter
    {
        void Initialize(IGameInfoView gameInfoView);
        void ShowView();
        
        void SetPlayerInfo(int playerIndex, LobbyPlayerData lobbyPlayerData);
        void SetDefaultPlayerInfo(int index);
        void SetRegion(string region);
        void SetRoomInfo(string name, bool isOpen, bool isVisible);
        void SetGameVersion(string gameVersion);
        void SetDefaultValue();
        
        void HideView();
    }
}