using Core.Data.RoomModel;
using ExitGames.Client.Photon;
using Lobby.LobbyRoomsParser.Interfaces;
using Photon.Realtime;

namespace Core.Services.PhotonServices.PhotonCustomProperty.Interfaces
{
    public interface ILobbyCustomPropertyAdapter
    {
        Hashtable GetCustomProperties(IRoomModel roomModel);
        string[] GetCustomPropertiesForLobby();
        
        IRoomModel GetRoomData(RoomInfo room);
        IRoomModel GetCurrentRoomData();
        void SetNewLobbyRoomData(IRoomModel roomModel);
    }
}