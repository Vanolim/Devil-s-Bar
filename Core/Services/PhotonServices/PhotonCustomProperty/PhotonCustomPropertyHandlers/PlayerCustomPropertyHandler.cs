using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace Core.Services.PhotonServices.PhotonCustomProperty.PhotonCustomPropertyHandlers
{
    public class PlayerCustomPropertyHandler
    {
        public void SetCurrentSceneLocalPlayer(string scene)
        {
            Hashtable customRoomData = new Hashtable
            {
                [CustomPlayerPropertyKeys.CurrentScene] = scene,
            };
            
            PhotonNetwork.LocalPlayer.SetCustomProperties(customRoomData);
        }

        public void SetGlobalGameBoardPlaceIndex(Player targetPlayer, int globalGameBoardPlaceIndex)
        {
            Hashtable customRoomData = new Hashtable
            {
                [CustomPlayerPropertyKeys.GlobalGameBoardPlaceIndex] = globalGameBoardPlaceIndex,
            };

            targetPlayer.SetCustomProperties(customRoomData);
        }
        
        public string GetPlayerCurrentScene(Player targetPlayer)
        {
            Hashtable playerProperty = targetPlayer.CustomProperties;
            
            if (playerProperty.TryGetValue(CustomPlayerPropertyKeys.CurrentScene, value: out var value))
            {
                string currentScene = (string)value;
                return currentScene;
            }

            return default;
        }
        
        public int GetGlobalGameBoardPlaceIndex(Player targetPlayer)
        {
            Hashtable playerProperty = targetPlayer.CustomProperties;
            
            if (playerProperty.TryGetValue(CustomPlayerPropertyKeys.GlobalGameBoardPlaceIndex, value: out var value))
            {
                int globalGameBoardPlaceIndex = (int)value;
                return globalGameBoardPlaceIndex;
            }

            return 0;
        }
    }
}