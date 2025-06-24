using UnityEngine;

namespace Core.Logic.CharacterCustomization.Data
{
    public class CharacterCustomizationData
    {
        public readonly string CharacterId;
        public readonly string CharacterName;
        public readonly string CharacterDescription;
        public readonly string Price;
        public readonly Sprite LockAvatar;
        public readonly Sprite UnlockAvatar;
        public readonly bool IsLock;
        
        public CharacterCustomizationData(string characterId, string characterName, string characterDescription, 
            string price, Sprite lockAvatar, Sprite unlockAvatar, bool isLock)
        {
            CharacterId = characterId;
            CharacterName = characterName;
            CharacterDescription = characterDescription;
            Price = price;
            LockAvatar = lockAvatar;
            UnlockAvatar = unlockAvatar;
            IsLock = isLock;
        }
    }
}