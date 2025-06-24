using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Interfaces
{
    public interface ICharacterModelBackgroundProvider
    {
        UniTask<ICharacterBackground> GetCharacterBackground(string characterId);
        UniTask<Sprite> GetSceneBackground(string characterId);
    }
}