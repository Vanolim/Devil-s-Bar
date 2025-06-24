using UnityEngine;

namespace Core.Data.GameplaySettingsData
{
    [CreateAssetMenu(fileName = "GameplaySettings", menuName = "ScriptableObjects/GameplaySettings")]
    public class GameplaySettingsData : ScriptableObject
    {
        [SerializeField] private int _countPlayerToStartGame;
        [SerializeField] private float _timeToStartGame;
        [SerializeField] private float _timeToSelectCard;
        [SerializeField] private float _timeToSayPatronType;
        [SerializeField] private float _timeToDecision;
        [SerializeField] private float _timeToShooterSelectTarget;
        [SerializeField] private float _timeToPlayingCard;
        [SerializeField] private float _timeToSelectNewShootTarget;
        [SerializeField] private int _weaponPatronCount;
        [SerializeField] private int _initialPlayerHealthValue;
        [SerializeField] private float _timeToShot;
        [SerializeField] private int _minBetToCreateLobby;
        
        public int CountPlayerToStartGame => _countPlayerToStartGame;
        public float TimeToStartGame => _timeToStartGame;
        public float TimeToSelectCard => _timeToSelectCard;
        public float TimeToSayPatronType => _timeToSayPatronType;
        public float TimeToDecision => _timeToDecision;
        public float TimeToShooterSelectTarget => _timeToShooterSelectTarget;
        public float TimeToPlayingCard => _timeToPlayingCard;
        public float TimeToSelectNewShootTarget => _timeToSelectNewShootTarget;
        public int WeaponPatronCount => _weaponPatronCount;
        public int InitialPlayerHealthValue => _initialPlayerHealthValue;
        public float TimeToShot => _timeToShot;
        public int MinBetToCreateLobby => _minBetToCreateLobby;
    }
}