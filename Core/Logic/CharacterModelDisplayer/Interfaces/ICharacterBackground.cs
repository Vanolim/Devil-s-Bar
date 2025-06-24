using Core.Managers.GameObjectManager;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Interfaces
{
    public interface ICharacterBackground : IBaseGameObject
    {
        void Activate();
        void Deactivate();
        void SetParent(Transform parent);
    }
}