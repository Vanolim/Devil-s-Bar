using System;
using Core.Managers.ScreenManager;
using UnityEngine;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationSlotView : IBaseScreen
    {
        void Initialize(Action<ICharacterCustomizationSlotView> select);
        
        void SetUnlockData(string name, Sprite avatar, bool isSelect);
        
        void SetLockData(Sprite avatar, string price);
        
        void SwitchToUnlock(Sprite newAvatar, bool isSelect); 
        
        void SwitchToLock(Sprite newAvatar, string price);

        void SetSelected(bool value);
        
        void SetParent(RectTransform parent);
    }
}