using System;
using Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints.Interfaces;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints
{
    [Serializable]
    public class CharacterSpawnPoint :ICharacterSpawnPoint
    {
        [SerializeField]
        private Transform _spawnPoint;

        [SerializeField]
        private string _characterId;
        
        public Transform SpawnPoint => _spawnPoint;
        
        public string CharacterId => _characterId;
    }
}