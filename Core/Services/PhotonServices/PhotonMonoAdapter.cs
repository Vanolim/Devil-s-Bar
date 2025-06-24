using System;
using System.Collections.Generic;
using System.Linq;
using Core.Managers.GameObjectManager;
using Core.Services.PhotonServices.Interfaces;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Core.Services.PhotonServices
{
    public class PhotonMonoAdapter : MonoBehaviourPunCallbacks, IOnEventCallback, IPhotonMonoAdapter
    {
        private event Action<EventData> _onPhotonEvent;
        private event Action<Player> _onPlayerEnteredRoom;
        private event Action<Player> _onOtherPlayerLeftRoom;
        private event Action _onJoinedRoom;
        private event Action _onCreatedRoom;
        private event Action _onLeftRoom;
        private event Action _onRoomPropertiesUpdate;
        private event Action<short, string> _onJoinRoomFailed;
        private event Action<List<RoomInfo>> _onRoomListUpdated;
        private event Action<short, string> _onCreateRoomFailed;
        private event Action _onConnectedToMaster;
        private event Action _onJoinedLobby;
        
        public event Action<IBaseGameObject> OnDestroyed;
        
        public override void OnEnable()
        {
            PhotonNetwork.AddCallbackTarget(this);
            base.OnEnable();
        }

        public void Initialize(
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
            Action joinedLobby)
        {
            _onPhotonEvent = photonEvent;
            _onPlayerEnteredRoom = playerEnteredRoom;
            _onOtherPlayerLeftRoom = playerLeftRoom;
            _onJoinedRoom = joinedRoom;
            _onCreatedRoom = createdRoom;
            _onLeftRoom = leftRoom;
            _onRoomPropertiesUpdate = roomPropertiesUpdated;
            _onJoinRoomFailed = joinRoomFailed;
            _onRoomListUpdated = roomListChanged;
            _onCreateRoomFailed = createRoomFailed;
            _onConnectedToMaster = connectedToPhotonMaster;
            _onJoinedLobby = joinedLobby;
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            _onRoomListUpdated?.Invoke(roomList);
            base.OnRoomListUpdate(roomList);
        }
        
        public override void OnConnectedToMaster()
        {
            _onConnectedToMaster?.Invoke();
            base.OnConnectedToMaster();
        }

        public override void OnCreatedRoom()
        {
            _onCreatedRoom?.Invoke();
            base.OnCreatedRoom();
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            _onCreateRoomFailed?.Invoke(returnCode, message);
            base.OnCreateRoomFailed(returnCode, message);
        }
        
        public override void OnJoinedLobby()
        {
            _onJoinedLobby?.Invoke();
            base.OnJoinedLobby();
        }
        
        public override void OnLeftRoom()
        {
            _onLeftRoom?.Invoke();
            base.OnLeftRoom();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            _onOtherPlayerLeftRoom?.Invoke(otherPlayer);
            base.OnPlayerLeftRoom(otherPlayer);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            _onPlayerEnteredRoom?.Invoke(newPlayer);
            base.OnPlayerEnteredRoom(newPlayer);
        }

        public override void OnJoinedRoom()
        {
            _onJoinedRoom?.Invoke();
            base.OnJoinedRoom();
        }
        
        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            _onJoinRoomFailed?.Invoke(returnCode, message);
            base.OnJoinRoomFailed(returnCode, message);
        }

        public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
        {
            _onRoomPropertiesUpdate?.Invoke();
            base.OnRoomPropertiesUpdate(propertiesThatChanged);
        }
        
        public void OnEvent(EventData photonEvent) => _onPhotonEvent?.Invoke(photonEvent);
        
        public override void OnDisable()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
            base.OnDisable();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}