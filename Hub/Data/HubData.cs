using System.Collections.Generic;

namespace Hub.Data
{
    public struct HubData
    {
        public readonly string CurrentCharacterId;
        public readonly IReadOnlyDictionary<string, bool> OpenCharacters;

        public HubData(string currentCharacterId, IReadOnlyDictionary<string, bool> openCharacters)
        {
            CurrentCharacterId = currentCharacterId;
            OpenCharacters = openCharacters;
        }
    }
}