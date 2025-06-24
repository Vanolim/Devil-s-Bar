using System.Collections.Generic;

namespace Core.Data.CharacterData
{
    public interface ICharacterDataProvider
    {
        IReadOnlyList<CharacterData> AllCharacters { get; }

        public string GetCharacterResourcesPath(string characterId);
    }
}