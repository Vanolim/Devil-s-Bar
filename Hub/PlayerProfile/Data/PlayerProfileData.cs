namespace Hub.PlayerProfile.Data
{
    public struct PlayerProfileData
    {
        public int AvatarIndex { get; }
        public string Name { get; }
        public int NameDiscriminator { get; }
        public int MatchesPlayed { get; }
        public float WinRate { get; }
        
        public PlayerProfileData(int avatarIndex, string name, int nameDiscriminator, int matchesPlayed, float winRate)
        {
            AvatarIndex = avatarIndex;
            Name = name;
            NameDiscriminator = nameDiscriminator;
            MatchesPlayed = matchesPlayed;
            WinRate = winRate;
        }
    }
}