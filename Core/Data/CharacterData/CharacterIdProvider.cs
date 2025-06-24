namespace Core.Data.CharacterData
{
    public static class CharacterIdProvider
    {
        public const string Gorilla = "char.gorillaz";
        public const string Dog = "char.dogma";
        public const string Rabbit = "char.hopsy";

        public static string GetId(CharacterType characterType)
        {
            switch (characterType)
            {
                case CharacterType.Gorilla:
                    return Gorilla;
                case CharacterType.Dog:
                    return Dog;
                case CharacterType.Rabbit:
                    return Rabbit;
                default:
                    return Gorilla;
            }
        }
        
        public static CharacterType GetType(string characterId)
        {
            switch (characterId)
            {
                case Gorilla:
                    return CharacterType.Gorilla;
                case Dog:
                    return CharacterType.Dog;
                case Rabbit:
                    return CharacterType.Rabbit;
                default:
                    return CharacterType.Gorilla;
            }
        }
    }

    public enum CharacterType
    {
        None = 0,
        Gorilla = 1,
        Dog = 2,
        Rabbit = 3,
    }
}