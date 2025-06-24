using System;
using System.Collections.Generic;
using Game.Services.GameDataUpdater;
using Photon.Realtime;

namespace Core.Services.PhotonServices.Interfaces
{
    public interface IPhotonEventHandler
    {
        event Action<string> OnCharacterRegistered;
        event Action<int> OnNewPlayerViewInstanced;
        event Action<GamePlayerUpdatedData> OnGamePlayerUpdated;
        event Action OnCreateRoom;
        event Action OnJoinedRoom;
        event Action OnLeftRoom;
        public event Action OnJoinedLobby;
        public event Action ConnectedToPhotonMaster;
        
        event Action<Player> OnNewPlayerJoined;
        event Action<Player> OnOtherPlayerLeftRoom;
        event Action OnRoomCustomPropertiesUpdate;
        event Action<List<RoomInfo>> OnRoomListUpdated;
        event Action<short, string> OnJoinedRoomFailed;
        public event Action<short, string> OnCreateRoomFailed;
    }
}