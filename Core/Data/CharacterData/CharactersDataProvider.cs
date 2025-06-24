using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Data.CharacterData
{
    public class CharactersDataProvider : ICharacterDataProvider
    {
        private readonly CharactersData _data;
        
        public IReadOnlyList<CharacterData> AllCharacters => _data.CharacterData;

        public CharactersDataProvider(CharactersData data)
        {
            _data = data;
        }

        public string GetCharacterResourcesPath(string characterId)
        {
            return GetCharacterData(characterId).ResourcesPath;
        }
        
        public string GetCharacterName(string characterId)
        {
            return GetCharacterData(characterId).Name;
        }

        public int GetCharacterPrice(string characterId)
        {
            return GetCharacterData(characterId).Price;
        }

        private CharacterData GetCharacterData(string characterId)
        {
            var charactersData = _data.CharacterData;
            
            var characterData = charactersData.FirstOrDefault(x => x.Id == characterId);
            
            if (characterData.Id != characterId)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterId}");
                return charactersData[Random.Range(0, charactersData.Count)];
            }

            return characterData;
        }
    }
}