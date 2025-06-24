using Cysharp.Threading.Tasks;
using Hub.Data;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Interfaces
{
    public interface ICharacterModelService
    {
        string CurrentCharacterId { get; }
        UniTask<CharacterDisplayData> GetNewCharacter(string characterId);
        UniTask<ICharacterBackground> GetCharacterBackground(string characterId);
        UniTask<Sprite> GetSceneBackground(string backgroundId);
    }
}