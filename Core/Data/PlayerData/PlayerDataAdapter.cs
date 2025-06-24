using System;
using Core.Services.SaveLoadService;
using Hub.PlayerProfile.Data;
using Hub.PlayerProfile.Interfaces;

namespace Core.Data.PlayerData
{
    public class PlayerDataAdapter : IPlayerDataProvider, IPlayerManualProfileServiceDataAdapter
    {
        private readonly ISaveLoadService _saveLoadService;
        
        public event Action OnPlayerProfileDataUpdated;

        public PlayerDataAdapter(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        
        public PlayerData GetPlayerData()
        {
            var saveData = _saveLoadService.CurrentData;
                
            PlayerData playerData = new PlayerData(
                saveData.PlayerName, 
                saveData.PlayerId, 
                saveData.SelectedCharacterId,
                (int)saveData.PlayerAvatarId,
                (int)saveData.NameDiscriminator,
                (int)saveData.MatchesPlayed,
                (float)saveData.WinRate);
                
            return playerData;
        }

        public PlayerProfileData GetPlayerProfileData()
        {
            var currentData = GetPlayerData();
            var playerProfileData = new PlayerProfileData(currentData.AvatarId,
                currentData.Name,
                currentData.NameDiscriminator,
                currentData.MatchesPlayed,
                currentData.WinRate);

            return playerProfileData;
        }

        public void SaveNewPlayerName(string newName)
        {
            if (newName != GetPlayerData().Name)
            {
                var saveData = _saveLoadService.CurrentData;
                saveData.PlayerName = newName;
                _saveLoadService.SaveData(saveData);
                
                OnPlayerProfileDataUpdated?.Invoke();
            }
        }
    }
}