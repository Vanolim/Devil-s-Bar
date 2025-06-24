using System;
using System.Collections.Generic;
using Core.Managers.GameObjectManager;
using Core.Services.PhotonServices.Interfaces;
using Core.Services.ResourcesLoadService;
using ExitGames.Client.Photon;
using Game.Card;
using Game.Player;
using Game.Services.GameDataUpdater;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Core.Services.PhotonServices.PhotonEventHandler
{
    public class PhotonEventHandler : IPhotonEventHandler, Zenject.IInitializable
    {
        private readonly ICoreGameObjectManger _coreGameObjectManger;
        
        public event Action<string> OnCharacterRegistered;
        
        public event Action<int> OnNewPlayerViewInstanced;
        public event Action<GamePlayerUpdatedData> OnGamePlayerUpdated;
        
        public event Action OnCreateRoom;
        public event Action OnJoinedRoom;
        public event Action OnLeftRoom;
        public event Action OnJoinedLobby;
        public event Action ConnectedToPhotonMaster;
        
        public event Action<Player> OnNewPlayerJoined;
        public event Action<Player> OnOtherPlayerLeftRoom;
        public event Action OnRoomCustomPropertiesUpdate;
        public event Action<List<RoomInfo>> OnRoomListUpdated;
        public event Action<short, string> OnJoinedRoomFailed;
        public event Action<short, string> OnCreateRoomFailed;
        
        public PhotonEventHandler(ICoreGameObjectManger coreGameObjectManger)
        {
            _coreGameObjectManger = coreGameObjectManger;
        }
        
        public async void Initialize()
        {
            var photonMonoAdapter = await _coreGameObjectManger.GetCoreObjectAsync<IPhotonMonoAdapter>
                (ResourcesProvider.Logic.PhotonMonoAdapter);
            
            photonMonoAdapter.Initialize(HandlePhotonEvent,
                NewPlayerJoinedEvent,
                OtherPlayerLeftRoomEvent,
                () => OnJoinedRoom?.Invoke(),
                () => OnCreateRoom?.Invoke(),
                () => OnLeftRoom?.Invoke(),
                () => OnRoomCustomPropertiesUpdate?.Invoke(),
                JoinedRoomFailedEvent,
                RoomListUpdateEvent,
                CreateRoomFailedEvent,
                () => ConnectedToPhotonMaster?.Invoke(),
                () => OnJoinedLobby?.Invoke());
        }
        
        private void HandlePhotonEvent(EventData photonEvent)
        {
            if (photonEvent.Code == PhotonEventCodeData.ViewSpawn)
            {
                object[] data = (object[])photonEvent.CustomData;
                string characterId = (string)data[0];
                OnCharacterRegistered?.Invoke(characterId);
            }
            if (photonEvent.Code == PhotonEventCodeData.PlayerViewInstanced)
            {
                object[] data = (object[])photonEvent.CustomData;
                int playerViewId = (int)data[0];
                OnNewPlayerViewInstanced?.Invoke(playerViewId);
            }

            if (photonEvent.Code == PhotonEventCodeData.GamePlayerUpdated)
            {
                object[] data = (object[])photonEvent.CustomData;
                
                GamePlayerUpdatedData gamePlayerUpdatedData = new GamePlayerUpdatedData(
                    (string)data[0],
                    (GamePlayerState)data[1],
                    (int)data[2],
                    (CardType)data[3],
                    (TrustType)data[4],
                    (bool)data[5]
                );
                
                OnGamePlayerUpdated?.Invoke(gamePlayerUpdatedData);
            }
        }

        private void NewPlayerJoinedEvent(Player newPlayer) => OnNewPlayerJoined?.Invoke(newPlayer);
        private void OtherPlayerLeftRoomEvent(Player leftPlayer) => OnOtherPlayerLeftRoom?.Invoke(leftPlayer);
        private void JoinedRoomFailedEvent(short errorCode, string errorMessage) => OnJoinedRoomFailed?.Invoke(errorCode, errorMessage);
        private void CreateRoomFailedEvent(short errorCode, string errorMessage) => OnCreateRoomFailed?.Invoke(errorCode, errorMessage);

        private void RoomListUpdateEvent(List<RoomInfo> rooms) => OnRoomListUpdated?.Invoke(rooms);
    }
}