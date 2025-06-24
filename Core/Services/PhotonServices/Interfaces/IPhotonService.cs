using Cysharp.Threading.Tasks;
using ExitGames.Client.Photon;
using Photon.Realtime;

namespace Core.Services.PhotonServices.Interfaces
{
    public interface IPhotonService
    {
        void SetPlayerId(string playerId);
        UniTask ConnectToMaster();
        UniTask<IPhotonOperationResult> TryJoinRoom(string roomName, string playerName);
        UniTask<IPhotonOperationResult> TryCreateRoom(string roomName, string playerName, Hashtable customProperty, string[] lobbyCustomProperty);
        UniTask LeaveRoom();
        UniTask JoinLobby();
    }
}