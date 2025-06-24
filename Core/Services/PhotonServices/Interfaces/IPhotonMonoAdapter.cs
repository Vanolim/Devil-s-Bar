using System;
using System.Collections.Generic;
using Core.Managers.GameObjectManager;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Core.Services.PhotonServices.Interfaces
{
    public interface IPhotonMonoAdapter : IBaseGameObject
    {
        void Initialize(
            Action<EventData> photonEvent, 
            Action<Player> playerEnteredRoom, 
            Action<Player> playerLeftRoom, 
            Action joinedRoom, 
            Action createdRoom, 
            Action leftRoom, 
            Action roomPropertiesUpdated, 
            Action<short, string> joinRoomFailed, 
            Action<List<RoomInfo>> roomListChanged,
            Action<short, string> createRoomFailed,
            Action connectedToPhotonMaster,
            Action joinedLobby); 
    }
}