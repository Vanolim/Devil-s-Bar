using Game.Data;

namespace Core.Services.PhotonServices.PhotonCustomProperty.Interfaces
{
    public interface IPhotonCustomPropertyAdapter
    {
        void SetNewGameRoomData(GameFlowData gameFlowData);
        void SetTargetGameFlowCustomProperty(string targetKey, object value);
        
        GameFlowData GetCurrentGameFlowData();
        void AddGameRoomCustomProperties(GameFlowData defaultGameFlowData);
    }
}