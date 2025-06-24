using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationSlotSpawner
    {
        UniTask<ICharacterCustomizationSlotView> GetUnlockSlot(string name, Sprite avatar, bool isSelect);
        UniTask<ICharacterCustomizationSlotView> GetLockSlot(Sprite avatar, string price);
    }
}