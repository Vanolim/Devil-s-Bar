using Core.Logic.CharacterModelDisplayer.Infrastructure;
using Core.Managers.GameObjectManager;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Interfaces
{
    public interface ICharacterPlace : IBaseGameObject
    {
        void SetCharacter(Transform character, string characterId, ShowCharacterType showCharacterType);
        void SetRenderCamera(Camera camera);
        void SetSceneBackground(Sprite sprite);
        void SetCharacterBackground(string characterId, ICharacterBackground characterBackground);
        void Deactivate();
    }
}