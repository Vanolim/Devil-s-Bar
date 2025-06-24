using System.Collections.Generic;
using System.Linq;
using Core.Data.CharacterData;
using Core.Logic.CharacterCustomization.Data;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Services.SaveLoadService;

namespace Core.Logic.CharacterCustomization.Infrastructure
{
    public class CharacterCustomizationDataAdapter : ICharacterCustomizationDataAdapter
    {
        private readonly ICharacterDataProvider _characterDataProvider;
        private readonly ISaveLoadService _saveLoadService;

        public CharacterCustomizationDataAdapter(ICharacterDataProvider characterDataProvider, ISaveLoadService saveLoadService)
        {
            _characterDataProvider = characterDataProvider;
            _saveLoadService = saveLoadService;
        }

        public CharacterCustomizationData GetCharactersCustomizationData(string characterId)
        {
            var data = GetCharacterCustomizationData(characterId, _saveLoadService.CurrentData.OpenCharacters, 
                _characterDataProvider.AllCharacters);

            return data;
        }

        public CharacterCustomizationData[] GetAllCharactersData()
        {
            var openCharacters = _saveLoadService.CurrentData.OpenCharacters;
            IReadOnlyList<CharacterData> allCharacters = _characterDataProvider.AllCharacters;
            
            CharacterCustomizationData[] data = new CharacterCustomizationData[allCharacters.Count];

            for (int i = 0; i < allCharacters.Count; i++)
            {
                var characterData = allCharacters[i];

                bool isCharacterLock = openCharacters.Contains(characterData.Id) == false;

                CharacterCustomizationData newData = new CharacterCustomizationData(
                    characterData.Id,
                    characterData.Name,
                    characterData.Description,
                    characterData.Price.ToString(),
                    characterData.LockAvatar,
                    characterData.UnlockAvatar,
                    isCharacterLock);
                
                data[i] = newData;
            }

            return data;
        }

        public void ChangeCharacter(string newCharacterId)
        {
            var currentData = _saveLoadService.CurrentData;
            currentData.SelectedCharacterId = newCharacterId;
            _saveLoadService.SaveData(currentData);
        }

        public string GetCurrentCharacterId()
        {
            return _saveLoadService.CurrentData.SelectedCharacterId;
        }

        private CharacterCustomizationData GetCharacterCustomizationData(string characterId, string[] openCharacters, IReadOnlyList<CharacterData> allCharacters)
        {
            var targetCharacter = allCharacters.First(x => x.Id == characterId);
            bool isCharacterLock = openCharacters.Contains(characterId) == false;
            
            CharacterCustomizationData newData = new CharacterCustomizationData(
                targetCharacter.Id,
                targetCharacter.Name,
                targetCharacter.Description,
                targetCharacter.Price.ToString(),
                targetCharacter.LockAvatar,
                targetCharacter.UnlockAvatar,
                isCharacterLock);

            return newData;
        }
    }
}