namespace Core.Data.GameplaySettingsData
{
    public class GameplaySettingsDataAdapter : IGameplaySettingsDataAdapter
    {
        private readonly GameplaySettingsData _gameplaySettingsData;

        public GameplaySettingsDataAdapter(GameplaySettingsData gameplaySettingsData)
        {
            _gameplaySettingsData = gameplaySettingsData;
        }

        public int CountPlayerToStartGame => _gameplaySettingsData.CountPlayerToStartGame;

        public float TimeToStartGame => _gameplaySettingsData.TimeToStartGame;

        public float TimeToSelectCard => _gameplaySettingsData.TimeToSelectCard;

        public float TimeToSayPatronType => _gameplaySettingsData.TimeToSayPatronType;

        public float TimeToDecision => _gameplaySettingsData.TimeToDecision;

        public float TimeToShooterSelectTarget => _gameplaySettingsData.TimeToShooterSelectTarget;

        public float TimeToPlayingCard => _gameplaySettingsData.TimeToPlayingCard;

        public float TimeToSelectNewShootTarget => _gameplaySettingsData.TimeToSelectNewShootTarget;

        public int WeaponPatronCount => _gameplaySettingsData.WeaponPatronCount;

        public int InitialPlayerHealthValue => _gameplaySettingsData.InitialPlayerHealthValue;

        public float TimeToShot => _gameplaySettingsData.TimeToShot;
        public int MinBetToCreateLobby => _gameplaySettingsData.MinBetToCreateLobby;
    }
}