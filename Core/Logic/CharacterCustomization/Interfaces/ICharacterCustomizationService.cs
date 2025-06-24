using Core.Logic.CharacterCustomization.Data;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationService
    {
        void SetSelectedCharacter(string characterId);

        ICharacterCustomizationSlotView GetSelectedSlot();
        
        CharacterCustomizationData GetCurrentCharacterData();
        CharacterCustomizationData GetCharacterCustomizationData(ICharacterCustomizationSlotView slot);
        
        UniTask<ICharacterCustomizationSlotView[]> GetCharactersSlot();
    }
}