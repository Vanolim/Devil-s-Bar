using System;
using Core.Services.PhotonServices.Data;
using Core.Services.PhotonServices.Interfaces;
using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Core.Services.PhotonServices
{
    public class PhotonService : IPhotonService
    {
        private readonly IPhotonEventHandler _photonEventHandler;
        
        public PhotonService(IPhotonEventHandler photonEventHandler)
        {
            _photonEventHandler = photonEventHandler;
        }

        public void SetPlayerId(string playerId)
        {
            PhotonNetwork.AuthValues = new AuthenticationValues
            {
                UserId = playerId
            };
        }

        public UniTask ConnectToMaster()
        {
            Debug.Log("Start connecting");
            PhotonNetwork.ConnectUsingSettings();
            return WaitingForConnectToPhotonMaster();
        }

        public async UniTask<IPhotonOperationResult> TryJoinRoom(string roomName, string playerName)
        {
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.AutomaticallySyncScene = false;
            //PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinRoom(roomName);
            
            return await WaitingForJoinRoom();
        }

        public async UniTask<IPhotonOperationResult> TryCreateRoom(string roomName, string playerName, 
            Hashtable customProperty, string[] lobbyCustomProperty)
        {
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.AutomaticallySyncScene = false;
            //PhotonNetwork.ConnectUsingSettings();
            
            TypedLobby typedLobby = new TypedLobby("MyLobby", LobbyType.SqlLobby);
            
            PhotonNetwork.CreateRoom(roomName, new RoomOptions
            {
                PublishUserId = true, 
                EmptyRoomTtl = 0,
                MaxPlayers = 3,
                CustomRoomProperties = customProperty,
                CustomRoomPropertiesForLobby = lobbyCustomProperty,
            }, typedLobby);
            
            return await WaitingForCreateRoom();
        }

        public UniTask LeaveRoom()
        {
            if (PhotonNetwork.InRoom)
            {
                PhotonNetwork.LeaveRoom();
                return WaitingForLeaveRoom();
            }

            return UniTask.CompletedTask;
        }

        public UniTask JoinLobby()
        {
            TypedLobby typedLobby = new TypedLobby("MyLobby", LobbyType.SqlLobby);
            PhotonNetwork.JoinLobby(typedLobby);
            
            return WaitingForJoinLobby();
        }

        private async UniTask<IPhotonOperationResult> WaitingForJoinRoom()
        {
            var tcs = new UniTaskCompletionSource<IPhotonOperationResult>();
            
            void OnSuccess()
            {
                Cleanup();
                IPhotonOperationResult photonOperationResult = new PhotonOperationResult(true);
                tcs.TrySetResult(photonOperationResult);
            }
            
            void OnFailure(short failureCode, string failureMessage)
            {
                Cleanup();
                IPhotonOperationResult photonOperationResult = new PhotonOperationResult(false, failureCode, failureMessage);
                tcs.TrySetResult(photonOperationResult);
            }
            
            void Cleanup()
            {
                _photonEventHandler.OnJoinedRoom -= OnSuccess;
                _photonEventHandler.OnJoinedRoomFailed -= OnFailure;
            }
            
            _photonEventHandler.OnJoinedRoom += OnSuccess;
            _photonEventHandler.OnJoinedRoomFailed += OnFailure;
            
            // if (PhotonNetwork.InRoom)
            // {
            //     OnSuccess();
            // }
            
            return await tcs.Task;
        }
        
        private async UniTask<IPhotonOperationResult> WaitingForCreateRoom()
        {
            var tcs = new UniTaskCompletionSource<IPhotonOperationResult>();

            void OnSuccess()
            {
                Cleanup();
                IPhotonOperationResult photonOperationResult = new PhotonOperationResult(true);
                tcs.TrySetResult(photonOperationResult);
            }

            void OnFailure(short failureCode, string failureMessage)
            {
                Cleanup();
                IPhotonOperationResult photonOperationResult = new PhotonOperationResult(false, failureCode, failureMessage);
                tcs.TrySetResult(photonOperationResult);
            }

            void Cleanup()
            {
                _photonEventHandler.OnCreateRoom -= OnSuccess;
                _photonEventHandler.OnJoinedRoomFailed -= OnFailure;
            }

            _photonEventHandler.OnCreateRoom += OnSuccess;
            _photonEventHandler.OnCreateRoomFailed += OnFailure;

            return await tcs.Task;
        }

        private UniTask WaitingForConnectToPhotonMaster()
        {
            var tcs = new UniTaskCompletionSource();

            void OnSuccess()
            {
                _photonEventHandler.ConnectedToPhotonMaster -= OnSuccess;
                tcs.TrySetResult();
            }

            _photonEventHandler.ConnectedToPhotonMaster += OnSuccess;
            
            return tcs.Task;
        }
        
        private UniTask WaitingForLeaveRoom()
        {
            var tcs = new UniTaskCompletionSource();

            void OnSuccess()
            {
                _photonEventHandler.OnLeftRoom -= OnSuccess;
                tcs.TrySetResult();
            }

            _photonEventHandler.OnLeftRoom += OnSuccess;

            if (PhotonNetwork.InRoom == false)
            {
                OnSuccess();
            }
            
            return tcs.Task;
        }
        
        private UniTask WaitingForJoinLobby()
        {
            var tcs = new UniTaskCompletionSource();

            void OnSuccess()
            {
                _photonEventHandler.OnJoinedLobby -= OnSuccess;
                
                Debug.Log(PhotonNetwork.NetworkClientState);
                tcs.TrySetResult();
            }

            _photonEventHandler.OnJoinedLobby += OnSuccess;
            
            if (PhotonNetwork.InLobby)
            {
                OnSuccess();
            }
            
            return tcs.Task;
        }
    }
}