using UnityEngine;

namespace Hub.PlayerProfile.Data
{
    public class PlayerProfileDisplayData
    {
        public Sprite Avatar { get; }
        public string Name { get; }
        public string NameDiscriminator { get; }
        public string MatchesPlayed { get; }
        public string WinRate { get; }
        
        public PlayerProfileDisplayData(Sprite avatar, string name, string nameDiscriminator, string matchesPlayed, string winRate)
        {
            Avatar = avatar;
            Name = name;
            NameDiscriminator = nameDiscriminator;
            MatchesPlayed = matchesPlayed;
            WinRate = winRate;
        }
    }
}