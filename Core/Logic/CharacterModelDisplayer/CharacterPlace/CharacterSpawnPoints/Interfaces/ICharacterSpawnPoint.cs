using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints.Interfaces
{
    public interface ICharacterSpawnPoint
    {
        Transform SpawnPoint { get; }
        string CharacterId { get; }
    }
}