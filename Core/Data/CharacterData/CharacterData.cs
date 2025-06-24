using System;
using UnityEngine;

namespace Core.Data.CharacterData
{
    [Serializable]
    public class CharacterData
    {
        [field: SerializeField]
        public string Id { get; private set; }
        
        [field: SerializeField]
        public string ResourcesPath { get; private set; }
        
        [field: SerializeField]
        public string Name { get; private set; }
        
        [field: SerializeField]
        public int Price { get; private set; }
        
        [field: SerializeField]
        public string Description { get; private set; }
        
        [field: SerializeField]
        public Sprite LockAvatar { get; private set; }
        
        [field: SerializeField]
        public Sprite UnlockAvatar { get; private set; }
    }
}