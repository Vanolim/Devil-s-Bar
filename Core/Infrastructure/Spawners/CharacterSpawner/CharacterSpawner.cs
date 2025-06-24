using System.Collections.Generic;
using System.Linq;
using Core.Data.CharacterData;
using Core.Infrastructure.Spawners.CharacterSpawner.Interfaces;
using Cysharp.Threading.Tasks;
using Photon.Pun;
using UnityEngine;
using Views.Player;

namespace Core.Infrastructure.Spawners.CharacterSpawner
{
    public class CharacterSpawner : ICharacterSpawner
    {
        private readonly ICharacterPhotonRegister _characterPhotonRegister;
        private readonly ICharacterDataProvider _charactersDataProvider;
        private readonly Dictionary<string, CharacterView> _activeCharacterViews = new();

        public CharacterSpawner(ICharacterPhotonRegister characterPhotonRegister, ICharacterDataProvider charactersDataProvider)
        {
            _characterPhotonRegister = characterPhotonRegister;
            _charactersDataProvider = charactersDataProvider;
        }

        public async UniTask<CharacterView> SpawnMineCharacter(string characterId, Transform spawnPoint)
        {
            await _characterPhotonRegister.RegisterPlayerView(characterId);
            
            string targetResourcesPath = _charactersDataProvider.GetCharacterResourcesPath(characterId);
            var character = PhotonNetwork.Instantiate(targetResourcesPath, spawnPoint.position, spawnPoint.rotation).GetComponent<CharacterView>();
            character.Activate();

            return character;
        }

        public async UniTask<CharacterView> GetCharacter(string characterId)
        {
            if (_activeCharacterViews.TryGetValue(characterId, out var characterView) && characterView != null)
            {
                return characterView;
            }
            
            CharacterView characterViewInstance = InstantiateCharacter(characterId);

            if (_activeCharacterViews.Keys.Contains(characterId))
            {
                _activeCharacterViews[characterId] = characterViewInstance;
            }
            else
            {
                _activeCharacterViews.Add(characterId, characterViewInstance);
            }
            
            characterViewInstance.Deactivate();
            return characterViewInstance;
        }

        private CharacterView InstantiateCharacter(string characterId)
        {
            string targetResourcesPath = _charactersDataProvider.GetCharacterResourcesPath(characterId);
            GameObject prefab = Resources.Load<GameObject>(targetResourcesPath);
            CharacterView character = Object.Instantiate(prefab).GetComponent<CharacterView>();
            return character;
        }
    }
}