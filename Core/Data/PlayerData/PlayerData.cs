namespace Core.Data.PlayerData
{
    public struct PlayerData
    {
        public string Name { get; }
        public string Id { get; }
        public string CharacterId { get; }
        public int AvatarId { get; }
        public int NameDiscriminator { get; }
        public int MatchesPlayed { get; }
        public float WinRate { get; }

        public PlayerData(string name, string id, string characterId, int avatarId,
            int nameDiscriminator, int matchesPlayed, float winRate)
        {
            Name = name;   
            Id = id;
            CharacterId = characterId;
            AvatarId = avatarId;
            NameDiscriminator = nameDiscriminator;
            MatchesPlayed = matchesPlayed;
            WinRate = winRate;
        }
    }
}