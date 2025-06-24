using System;
using Core.Data.CharacterData;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.SelectedCharacterPlaceSpawnPointsData
{
    [Serializable]
    public struct SelectedCharacterPlaceSpawnPointData
    {
        public Transform SpawnPoint;
        public CharacterType CharacterType;
    }
}