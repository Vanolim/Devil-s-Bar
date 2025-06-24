using Cysharp.Threading.Tasks;

namespace Core.Infrastructure.Spawners.CharacterSpawner.Interfaces
{
    public interface ICharacterPhotonRegister
    {
        UniTask RegisterPlayerView(string characterId);
    }
}