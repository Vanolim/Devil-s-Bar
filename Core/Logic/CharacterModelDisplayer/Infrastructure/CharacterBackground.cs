using System;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.GameObjectManager;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.Infrastructure
{
    public class CharacterBackground : MonoBehaviour, ICharacterBackground
    {
        public event Action<IBaseGameObject> OnDestroyed;
        
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void SetParent(Transform parent)
        {
            gameObject.transform.parent = parent;
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}