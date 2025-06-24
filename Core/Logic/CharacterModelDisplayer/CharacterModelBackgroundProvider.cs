using System.Collections.Generic;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.GameObjectManager;
using Core.Services.ResourcesLoadService;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterModelDisplayer
{
    public class CharacterModelBackgroundProvider : ICharacterModelBackgroundProvider
    {
        private readonly IResourcesLoadService _resourcesLoadService;
        private readonly ICoreGameObjectManger _gameObjectManager;
        
        private readonly Dictionary<string, Sprite> _loadedSceneBackgrounds = new();
        private readonly Dictionary<string, ICharacterBackground> _loadedCharacterBackground = new();

        public CharacterModelBackgroundProvider(IResourcesLoadService resourcesLoadService, ICoreGameObjectManger gameObjectManager)
        {
            _resourcesLoadService = resourcesLoadService;
            _gameObjectManager = gameObjectManager;
        }

        public async UniTask<ICharacterBackground> GetCharacterBackground(string backgroundId)
        {
            if (_loadedCharacterBackground.TryGetValue(backgroundId, out ICharacterBackground loadedBackground))
            {
                return loadedBackground;
            }

            ICharacterBackground newBackground = await _gameObjectManager.GetCoreObjectAsync<ICharacterBackground>(backgroundId);
            _loadedCharacterBackground.Add(backgroundId, newBackground);

            return newBackground;
        }

        public async UniTask<Sprite> GetSceneBackground(string backgroundId)
        {
            if (_loadedSceneBackgrounds.TryGetValue(backgroundId, out Sprite loadedBackground))
            {
                return loadedBackground;
            }

            Sprite newBackground = await _resourcesLoadService.LoadAsync<Sprite>(backgroundId, SceneLifeTimeHolder.ProjectLifeTime);
            _loadedSceneBackgrounds.Add(backgroundId, newBackground);

            return newBackground;
        }
    }
}