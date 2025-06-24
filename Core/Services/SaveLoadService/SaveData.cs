#nullable enable

namespace Core.Services.SaveLoadService
{
    [System.Serializable]
    public struct SaveData
    {
        public string? PlayerName;
        public string? PlayerId;
        public string? SelectedCharacterId;
        public int? PlayerAvatarId;
        public int? NameDiscriminator;
        public int? MatchesPlayed;
        public float? WinRate;
        public bool? IsSimpleGame;
        public string[]? OpenCharacters;
        public int? CurrentLobbyRoomType;
        public int? CurrentLobbyBet;
        public int? HardCurrency;
        public string[]? Purchases;

        public SaveData(
            string playerName, 
            string playerId, 
            string selectedCharacterId, 
            int playerAvatarId, 
            int nameDiscriminator, 
            int matchesPlayed, 
            float winRate, 
            bool isSimpleGame, 
            string[] openCharacters, 
            int currentLobbyRoomType, 
            int currentLobbyBet,
            int hardCurrency,
            string[] purchases)
        {
            PlayerName = playerName;
            PlayerId = playerId;
            SelectedCharacterId = selectedCharacterId;
            PlayerAvatarId = playerAvatarId;
            NameDiscriminator = nameDiscriminator;
            MatchesPlayed = matchesPlayed;
            WinRate = winRate;
            IsSimpleGame = isSimpleGame;
            OpenCharacters = openCharacters;
            CurrentLobbyRoomType = currentLobbyRoomType;
            CurrentLobbyBet = currentLobbyBet;
            HardCurrency = hardCurrency;
            Purchases = purchases;
        }
    }
}