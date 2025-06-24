using System.Linq;
using Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints.Interfaces;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints
{
    public class CharacterSpawnPointsHandler : MonoBehaviour
    {
        [SerializeField]
        private CharacterSpawnPointsParent[] _spawnPoints;

        public Transform GetCharacterSpawnPointAndActivate(CharacterSpawnPointsType pointType, string characterId)
        {
            ICharacterSpawnPointsParent pointParent = _spawnPoints.FirstOrDefault(x => x.PointsType == pointType);

            if (pointParent == null)
            {
                Debug.LogError($"Container {_spawnPoints} does not contain points {pointType}");
                pointParent = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            }
            
            var characterSpawnPoint = pointParent.GetSpawnPoint(characterId);
            //characterSpawnPoint.Activate();
            
            pointParent.Activate();

            return characterSpawnPoint.SpawnPoint;
        }

        public void DeactivateSpawnPoints(CharacterSpawnPointsType pointType)
        {
            
        }
    }
}