namespace Core.Services.PhotonServices.PhotonCustomProperty.PhotonCustomPropertyHandlers
{
    public static class CustomPropertyKeys
    {
        public static class Core
        {
            public const string PlayersId = "PlayersId";
            public const string CharactersId = "CharactersId";
        }
        
        public static class Lobby
        {
            public const string LobbyType = "LobbyType";
            public const string Bet = "Bet";
            public const string ReadyCharacters = "ReadyCharacters";
        }

        public static class Game
        {
            public const string PlayerPlace = "PlayerPlace";
            public const string GameLoopManagerId = "GameLoopManagerId";
            public const string CurrentState = "CurrentState";
            public const string ShooterSaidPatronType = "ShooterSaidPatronType";
            public const string ShootTargetId = "ShootTargetId";
            public const string AdditionalCards = "AdditionalCards";
            public const string AdditionalCardPlaceIndex = "AdditionalCardPlaceIndex";
            public const string WeaponPatrons = "WeaponPatrons";
            public const string CardDeckCards = "CardDeckCards";
            public const string IsWeaponDoubleShoot = "IsWeaponDoubleShoot";
            public const string GameRoomState = "GameRoomState";
        }
    }
}