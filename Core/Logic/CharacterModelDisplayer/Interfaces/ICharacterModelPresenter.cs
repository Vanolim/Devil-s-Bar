using Core.Logic.CharacterModelDisplayer.Infrastructure;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Interfaces
{
    public interface ICharacterModelPresenter
    {
        UniTask ShowCurrentCharacterWithCharacterBackground(ShowCharacterType showCharacterType = ShowCharacterType.Default);
        UniTask ShowCharacterWithCharacterBackground(string characterId, ShowCharacterType showCharacterType = ShowCharacterType.Default);

        UniTask ShowCharacterWithSceneBackground(string characterId, string backgroundId, ShowCharacterType showCharacterType = ShowCharacterType.Default);
        UniTask ShowCurrentCharacterWithSceneBackground(string backgroundId, ShowCharacterType showCharacterType = ShowCharacterType.Default);

        UniTask ShowCharacterWithoutBackground(string characterId, ShowCharacterType showCharacterType = ShowCharacterType.Default);

        void HideLobbyCharacter(ShowCharacterType showCharacterType);
        
        void SetRenderCamera(Camera camera);
        void Hide();
    }
}