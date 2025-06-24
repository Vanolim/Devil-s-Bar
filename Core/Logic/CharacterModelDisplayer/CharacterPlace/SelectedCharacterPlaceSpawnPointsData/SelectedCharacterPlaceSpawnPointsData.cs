using System.Collections.Generic;
using System.Linq;
using Core.Data.CharacterData;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.SelectedCharacterPlaceSpawnPointsData
{
    public class SelectedCharacterPlaceSpawnPointsData : MonoBehaviour
    {
        [SerializeField]
        private List<SelectedCharacterPlaceSpawnPointData> _data;
        
        [SerializeField]
        private List<SelectedCharacterPlaceSpawnPointData> _right;
        
        [SerializeField] 
        private List<SelectedCharacterPlaceSpawnPointData> _centerLobbySpawnPoints; 
        
        [SerializeField] 
        private List<SelectedCharacterPlaceSpawnPointData> _leftLobbySpawnPoints; 
        
        [SerializeField] 
        private List<SelectedCharacterPlaceSpawnPointData> _rightLobbySpawnPoints; 
        
        [SerializeField] 
        private List<SelectedCharacterPlaceSpawnPointData> _characterBackgroundSpawnPoints; 

        public Transform GetSpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _data.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _data[Random.Range(0, _data.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }
        
        public Transform GetRightSpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _right.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _right[Random.Range(0, _right.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }
        
        public Transform GetCenterLobbySpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _centerLobbySpawnPoints.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _centerLobbySpawnPoints[Random.Range(0, _centerLobbySpawnPoints.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }
        
        public Transform GetLeftLobbySpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _leftLobbySpawnPoints.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _leftLobbySpawnPoints[Random.Range(0, _leftLobbySpawnPoints.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }
        
        public Transform GetRightLobbySpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _rightLobbySpawnPoints.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _rightLobbySpawnPoints[Random.Range(0, _rightLobbySpawnPoints.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }

        public Transform GetCharacterBackgroundSpawnPoint(string characterId)
        {
            CharacterType characterType = CharacterIdProvider.GetType(characterId);

            var selectedCharacterPlaceSpawnPointData = _characterBackgroundSpawnPoints.FirstOrDefault(x => x.CharacterType == characterType);
            
            if (selectedCharacterPlaceSpawnPointData.CharacterType != characterType)
            {
                Debug.LogError($"Container {GetType()} does not contain character {characterType}");
                return _characterBackgroundSpawnPoints[Random.Range(0, _characterBackgroundSpawnPoints.Count)].SpawnPoint;
            }

            return selectedCharacterPlaceSpawnPointData.SpawnPoint;
        }

        public Transform[] GetAllCharacterBackgroundSpawnPoints()
        {
            return _characterBackgroundSpawnPoints.Select(x => x.SpawnPoint).ToArray();
        }
    }
}