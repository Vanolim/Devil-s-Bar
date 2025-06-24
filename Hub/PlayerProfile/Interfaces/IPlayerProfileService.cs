using System;
using Hub.PlayerProfile.Data;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IPlayerProfileService
    {
        public event Action OnPlayerProfileDataUpdated;
        public PlayerProfileDisplayData GetPlayerProfileDisplayData();
        public void ChangePlayerName(string newName);
        public string GetPlayerName();
    }
}