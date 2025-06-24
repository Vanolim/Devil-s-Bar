using System.Linq;
using Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints.Interfaces;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints
{
    public class CharacterSpawnPointsParent : MonoBehaviour, ICharacterSpawnPointsParent
    {
        [SerializeField]
        private CharacterSpawnPointsType _pointsType;

        [SerializeField]
        private CharacterSpawnPoint[] _spawnPoints;
        
        public CharacterSpawnPointsType PointsType => _pointsType;

        public ICharacterSpawnPoint GetSpawnPoint(string characterId)
        {
            var characterPoint = _spawnPoints.FirstOrDefault(x => x.CharacterId == characterId);
            
            if (characterPoint == null)
            {
                Debug.LogError($"Container {_pointsType} does not contain character {characterId}");
                return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            }

            return characterPoint;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            DeactivatePoints();
            gameObject.SetActive(false);
        }

        public void DeactivatePoints()
        {
            foreach (var spawnPoint in _spawnPoints)
            {
                //spawnPoint.Deactivate();
            }
        }
    }
}