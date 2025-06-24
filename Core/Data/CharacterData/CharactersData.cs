using System.Collections.Generic;
using UnityEngine;

namespace Core.Data.CharacterData
{
    [CreateAssetMenu(fileName = "CharactersProvider", menuName = "ScriptableObjects/CharactersProvider")]
    public class CharactersData : ScriptableObject
    {
        [SerializeField] private List<CharacterData> _charactersData;
        
        public IReadOnlyList<CharacterData> CharacterData => _charactersData;
    }
}