using System;
using Hub.PlayerProfile.Data;
using Hub.PlayerProfile.Data.PlayerAvatarData;
using Hub.PlayerProfile.Interfaces;
using UnityEngine;
using Zenject;

namespace Hub.PlayerProfile
{
    public class PlayerManualProfileService : IPlayerProfileService, IInitializable, IDisposable
    {
        private readonly IPlayerManualProfileServiceDataAdapter _dataAdapter;
        private readonly PlayerAvatarsData _playerAvatarsData;
        
        public event Action OnPlayerProfileDataUpdated;

        public PlayerManualProfileService(IPlayerManualProfileServiceDataAdapter dataAdapter, PlayerAvatarsData playerAvatarsData)
        {
            _dataAdapter = dataAdapter;
            _playerAvatarsData = playerAvatarsData;
        }
        
        public void Initialize()
        {
            _dataAdapter.OnPlayerProfileDataUpdated += UpdatePlayerProfileData;
        }

        public void ChangePlayerName(string newName) => _dataAdapter.SaveNewPlayerName(newName);

        public string GetPlayerName() => _dataAdapter.GetPlayerProfileData().Name;

        public PlayerProfileDisplayData GetPlayerProfileDisplayData()
        {
            PlayerProfileData playerProfileData = _dataAdapter.GetPlayerProfileData();

            PlayerProfileDisplayData playerProfileDisplayData = new PlayerProfileDisplayData(
                avatar: GetPlayerAvatar(playerProfileData.AvatarIndex),
                name: playerProfileData.Name,
                nameDiscriminator: playerProfileData.NameDiscriminator.ToString(),
                matchesPlayed: playerProfileData.MatchesPlayed.ToString(),
                winRate: GetFloorPlayerWinRate(playerProfileData.WinRate));

            return playerProfileDisplayData;
        }

        private void UpdatePlayerProfileData() => OnPlayerProfileDataUpdated?.Invoke();

        private Sprite GetPlayerAvatar(int avatarId) => _playerAvatarsData.GetAvatar(avatarId);

        private string GetFloorPlayerWinRate(float winRate)
        {
            int flooredValue = Mathf.FloorToInt(winRate);
            return flooredValue.ToString();
        }

        public void Dispose()
        {
            _dataAdapter.OnPlayerProfileDataUpdated -= UpdatePlayerProfileData;
        }
    }
}