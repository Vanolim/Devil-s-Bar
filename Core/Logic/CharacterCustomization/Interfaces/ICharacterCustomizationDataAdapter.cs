using Core.Logic.CharacterCustomization.Data;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationDataAdapter
    {
        CharacterCustomizationData GetCharactersCustomizationData(string characterId);
        CharacterCustomizationData[] GetAllCharactersData();
        void ChangeCharacter(string newCharacterId);
        string GetCurrentCharacterId();
    }
}