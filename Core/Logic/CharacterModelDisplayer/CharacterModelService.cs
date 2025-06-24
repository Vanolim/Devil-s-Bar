using Core.Data.CharacterData;
using Core.Data.PlayerData;
using Core.Infrastructure.Spawners.CharacterSpawner.Interfaces;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;
using Hub.Data;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer
{
    public class CharacterModelService : ICharacterModelService
    {
        private readonly IPlayerDataProvider _playerDataProvider;
        private readonly ICharacterSpawner _characterSpawner;
        private readonly ICharacterModelBackgroundProvider _characterModelBackgroundProvider;

        public string CurrentCharacterId => _playerDataProvider.GetPlayerData().CharacterId;

        public CharacterModelService(IPlayerDataProvider playerDataProvider, ICharacterSpawner characterSpawner,
            ICharacterModelBackgroundProvider characterModelBackgroundProvider)
        {
            _playerDataProvider = playerDataProvider;
            _characterSpawner = characterSpawner;
            _characterModelBackgroundProvider = characterModelBackgroundProvider;
        }

        public async UniTask<CharacterDisplayData> GetNewCharacter(string characterId)
        {
            var character = await _characterSpawner.GetCharacter(characterId);
            return new CharacterDisplayData(characterId, character);
        }

        public UniTask<ICharacterBackground> GetCharacterBackground(string characterId)
        {
            string characterBackgroundId = GetCharacterBackgroundId(characterId);
            return _characterModelBackgroundProvider.GetCharacterBackground(characterBackgroundId);
        }

        public UniTask<Sprite> GetSceneBackground(string backgroundId)
        {
            return _characterModelBackgroundProvider.GetSceneBackground(backgroundId);
        }

        private string GetCharacterBackgroundId(string characterId)
        {
            switch (characterId)
            {
                case CharacterIdProvider.Gorilla:
                    return ResourcesProvider.CharacterBackground.GorillazBackground;
                case CharacterIdProvider.Dog:
                    return ResourcesProvider.CharacterBackground.DogmaBackground;
                case CharacterIdProvider.Rabbit:
                    return ResourcesProvider.CharacterBackground.HopsyBackground;
                default:
                    return ResourcesProvider.CharacterBackground.GorillazBackground;
            }
        }
    }
}