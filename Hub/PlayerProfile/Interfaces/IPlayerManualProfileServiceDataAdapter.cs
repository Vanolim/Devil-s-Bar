using System;
using Hub.PlayerProfile.Data;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IPlayerManualProfileServiceDataAdapter
    {
        public event Action OnPlayerProfileDataUpdated;
        public PlayerProfileData GetPlayerProfileData();
        public void SaveNewPlayerName(string newName);
    }
}