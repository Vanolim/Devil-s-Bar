using System.Linq;
using Core.Data.RoomModel;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Services.PhotonServices.PhotonCustomProperty.PhotonCustomPropertyHandlers
{
    public class LobbyRoomCustomPropertiesHandler
    {
        public Hashtable GetCustomProperties(IRoomModel roomModel)
        {
            Hashtable customRoomData = new Hashtable
            {
                [CustomPropertyKeys.Lobby.LobbyType] = (int)roomModel.RoomType,
                [CustomPropertyKeys.Lobby.Bet] = roomModel.Bet,
                [CustomPropertyKeys.Lobby.ReadyCharacters] = roomModel.ReadyPlayers,
                [CustomPropertyKeys.Core.PlayersId] = roomModel.Players.ToArray(),
                [CustomPropertyKeys.Core.CharactersId] = roomModel.Characters.ToArray()
            };
            
            return customRoomData;
        }

        public string[] GetCustomPropertiesForLobby()
        {
            return new[]
            {
                CustomPropertyKeys.Lobby.LobbyType,
                CustomPropertyKeys.Lobby.Bet,
                CustomPropertyKeys.Lobby.ReadyCharacters,
                CustomPropertyKeys.Core.PlayersId,
                CustomPropertyKeys.Core.CharactersId
            };
        }

        public void SetNewLobbyRoomData(IRoomModel roomModel) => 
            PhotonNetwork.CurrentRoom.SetCustomProperties(GetCustomProperties(roomModel));

        public IRoomModel GetLobbyRoomData(RoomInfo room)
        {
            var data = room.CustomProperties;

            string roomName = room.Name;

            RoomType roomType = (RoomType)data[CustomPropertyKeys.Lobby.LobbyType];
            int bet = (int)data[CustomPropertyKeys.Lobby.Bet];
            string[] playersId = (string[])data[CustomPropertyKeys.Core.PlayersId];
            string[] charactersId = (string[])data[CustomPropertyKeys.Core.CharactersId];
            bool[] readyCharacters = (bool[])data[CustomPropertyKeys.Lobby.ReadyCharacters];

            return new RoomModel(roomName, roomType, bet, playersId, charactersId, readyCharacters);
        }
    }
}