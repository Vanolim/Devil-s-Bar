using Cysharp.Threading.Tasks;
using UnityEngine;
using Views.Player;

namespace Core.Infrastructure.Spawners.CharacterSpawner.Interfaces
{
    public interface ICharacterSpawner
    {
        UniTask<CharacterView> GetCharacter(string characterId);
        UniTask<CharacterView> SpawnMineCharacter(string characterId, Transform spawnPoint);
    }
}