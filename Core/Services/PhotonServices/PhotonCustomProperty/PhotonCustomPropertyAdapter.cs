using Core.Data.RoomModel;
using Core.Services.PhotonServices.PhotonCustomProperty.Interfaces;
using Core.Services.PhotonServices.PhotonCustomProperty.PhotonCustomPropertyHandlers;
using ExitGames.Client.Photon;
using Game.Data;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Services.PhotonServices.PhotonCustomProperty
{
    public class PhotonCustomPropertyAdapter : IPhotonCustomPropertyAdapter, ILobbyCustomPropertyAdapter, IPlayerCustomPropertyAdapter
    {
        private readonly LobbyRoomCustomPropertiesHandler _lobbyRoomCustomPropertiesHandler = new();
        private readonly GameFlowCustomPropertiesHandler _gameFlowCustomPropertiesHandler = new();
        private readonly PlayerCustomPropertyHandler _playerCustomPropertyHandler = new();

        public Hashtable GetCustomProperties(IRoomModel roomModel)
        {
            return _lobbyRoomCustomPropertiesHandler.GetCustomProperties(roomModel);
        }

        public string[] GetCustomPropertiesForLobby()
        {
            return _lobbyRoomCustomPropertiesHandler.GetCustomPropertiesForLobby();
        }

        public void SetNewGameRoomData(GameFlowData gameFlowData)
        {
            _gameFlowCustomPropertiesHandler.SetNewGameFlowData(gameFlowData);
        }

        public void SetTargetGameFlowCustomProperty(string targetKey, object value)
        {
            _gameFlowCustomPropertiesHandler.SetTargetCustomProperty(targetKey, value);
        }

        public IRoomModel GetRoomData(RoomInfo room)
        {
            return _lobbyRoomCustomPropertiesHandler.GetLobbyRoomData(room);
        }
        
        public IRoomModel GetCurrentRoomData()
        {
            var currentRoom = PhotonNetwork.CurrentRoom;
            return _lobbyRoomCustomPropertiesHandler.GetLobbyRoomData(currentRoom);
        }

        public void SetNewLobbyRoomData(IRoomModel roomModel)
        {
            _lobbyRoomCustomPropertiesHandler.SetNewLobbyRoomData(roomModel);
        }

        public GameFlowData GetCurrentGameFlowData()
        {
            return _gameFlowCustomPropertiesHandler.GetCurrentGameFlowData();
        }

        public void AddGameRoomCustomProperties(GameFlowData defaultGameFlowData)
        {
            PhotonNetwork.CurrentRoom.SetCustomProperties(_gameFlowCustomPropertiesHandler.GetCustomProperties(defaultGameFlowData));
        }

        public void SetCurrentSceneLocalPlayer(string scene)
        {
            _playerCustomPropertyHandler.SetCurrentSceneLocalPlayer(scene);
        }

        public void SetGlobalGameBoardPlaceIndex(Player targetPlayer, int globalGameBoardPlaceIndex)
        {
            _playerCustomPropertyHandler.SetGlobalGameBoardPlaceIndex(targetPlayer, globalGameBoardPlaceIndex);
        }

        public string GetPlayerCurrentScene(Player targetPlayer)
        {
            return _playerCustomPropertyHandler.GetPlayerCurrentScene(targetPlayer);
        }

        public int GetGlobalGameBoardPlaceIndex(Player targetPlayer)
        {
            return _playerCustomPropertyHandler.GetGlobalGameBoardPlaceIndex(targetPlayer);
        }
    }
}