namespace Core.Data.GameplaySettingsData
{
    public interface IGameplaySettingsDataAdapter
    {
        int CountPlayerToStartGame { get; }
        float TimeToStartGame { get; }
        float TimeToSelectCard { get; }
        float TimeToSayPatronType { get; }
        float TimeToDecision { get; }
        float TimeToShooterSelectTarget { get; }
        float TimeToPlayingCard { get; }
        float TimeToSelectNewShootTarget { get; }
        int WeaponPatronCount { get; }
        int InitialPlayerHealthValue { get; }
        float TimeToShot { get; }
        int MinBetToCreateLobby { get; }
    }
}