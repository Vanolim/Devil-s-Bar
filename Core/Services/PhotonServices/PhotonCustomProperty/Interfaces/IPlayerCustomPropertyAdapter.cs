using Photon.Realtime;

namespace Core.Services.PhotonServices.PhotonCustomProperty.Interfaces
{
    public interface IPlayerCustomPropertyAdapter
    {
        void SetCurrentSceneLocalPlayer(string scene);
        void SetGlobalGameBoardPlaceIndex(Player targetPlayer, int globalGameBoardPlaceIndex);
        string GetPlayerCurrentScene(Player targetPlayer);
        int GetGlobalGameBoardPlaceIndex(Player targetPlayer);
    }
}