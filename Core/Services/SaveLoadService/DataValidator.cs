using System;
using Random = UnityEngine.Random;

namespace Core.Services.SaveLoadService
{
    public class DataValidator
    {
        private const string DefaultPlayerName = "PLAYER_NAME";
        private const string DefaultSelectedCharacterId = "char.gorillaz";
        private const int DefaultPlayerAvatarId = 0;
        private const int DefaultMatchesPlayed = 0;
        private const float DefaultWinRate = 0;
        private const bool DefaultIsSimpleGame = true;
        private const int DefaultLobbyRoomType = 0;
        private const int DefaultLobbyBet = 10;
        private const int DefaultHardCurrency = 1000;
        
        private string DefaultPlayerId => Guid.NewGuid().ToString();
        private int DefaultNameDiscriminator => Convert.ToInt32(Random.Range(1, 9999).ToString("D4"));

        private string[] DefaultOpenCharacters => new[]
        { 
            "char.gorillaz", "char.hopsy", "char.dogma"
        };

        private string[] DefaultPurchases = new string[0];

        public bool ValidateData(ref SaveData saveData)
        {
            bool isValidate = true;
            if (saveData.PlayerName == null)
            {
                saveData.PlayerName = DefaultPlayerName;
                isValidate = false;
            }
            if (saveData.PlayerId == null)
            {
                saveData.PlayerId = DefaultPlayerId;
                isValidate = false;
            }
            if (saveData.SelectedCharacterId == null)
            {
                saveData.SelectedCharacterId = DefaultSelectedCharacterId;
                isValidate = false;
            }
            if (saveData.PlayerAvatarId == null)
            {
                saveData.PlayerAvatarId = DefaultPlayerAvatarId;
                isValidate = false;
            }
            if (saveData.NameDiscriminator == null)
            {
                saveData.NameDiscriminator = DefaultNameDiscriminator;
                isValidate = false;
            }
            if (saveData.MatchesPlayed == null)
            {
                saveData.MatchesPlayed = DefaultMatchesPlayed;
                isValidate = false;
            }
            if (saveData.WinRate == null)
            {
                saveData.WinRate = DefaultWinRate;
                isValidate = false;
            }
            if (saveData.IsSimpleGame == null)
            {
                saveData.IsSimpleGame = DefaultIsSimpleGame;
                isValidate = false;
            }

            if (saveData.OpenCharacters == null)
            {
                saveData.OpenCharacters = DefaultOpenCharacters;
                isValidate = false;
            }
            
            if (saveData.CurrentLobbyRoomType == null)
            {
                saveData.CurrentLobbyRoomType = DefaultLobbyRoomType;
                isValidate = false;
            }

            if (saveData.CurrentLobbyBet == null)
            {
                saveData.CurrentLobbyBet = DefaultLobbyBet;
                isValidate = false;
            }
            
            if (saveData.HardCurrency == null)
            {
                saveData.HardCurrency = DefaultHardCurrency;
                isValidate = false;
            }

            return isValidate;
        }

        public SaveData GetDefaultData()
        {
            return new SaveData(
                playerName: DefaultPlayerName,
                playerId: DefaultPlayerId,
                selectedCharacterId: DefaultSelectedCharacterId,
                playerAvatarId: DefaultPlayerAvatarId,
                nameDiscriminator: DefaultNameDiscriminator,
                matchesPlayed: DefaultMatchesPlayed,
                winRate: DefaultWinRate,
                isSimpleGame: DefaultIsSimpleGame,
                openCharacters: DefaultOpenCharacters,
                currentLobbyRoomType: DefaultLobbyRoomType,
                currentLobbyBet: DefaultLobbyBet,
                hardCurrency: DefaultHardCurrency,
                purchases: DefaultPurchases);
        }
    }
}