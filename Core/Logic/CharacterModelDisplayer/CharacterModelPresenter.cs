using System.Collections.Generic;
using System.Linq;
using Core.Logic.CharacterModelDisplayer.Infrastructure;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.GameObjectManager;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;
using Hub.Data;
using UnityEngine;
using Views.Player;

namespace Core.Logic.CharacterModelDisplayer
{
    public class CharacterModelPresenter : ICharacterModelPresenter
    {
        private readonly ICharacterModelService _characterModelService;
        private readonly ICoreGameObjectManger _coreGameObjectManager;
        private readonly Dictionary<ShowCharacterType, CharacterDisplayData> _lobbyDisplayCharacter;

        private ICharacterPlace _characterPlace;
        private CharacterDisplayData _currentDisplayCharacter;
        private Camera _currentCamera;

        public CharacterModelPresenter(ICoreGameObjectManger coreGameObjectManager, ICharacterModelService characterModelService)
        {
            _coreGameObjectManager = coreGameObjectManager;
            _characterModelService = characterModelService;

            _lobbyDisplayCharacter = new Dictionary<ShowCharacterType, CharacterDisplayData>()
            {
                { ShowCharacterType.LobbyRoomLeft, default },
                { ShowCharacterType.LobbyRoomCenter, default },
                { ShowCharacterType.LobbyRoomRight, default },
            };
        }
        
        public UniTask ShowCurrentCharacterWithCharacterBackground(ShowCharacterType showCharacterType = ShowCharacterType.Default)
        {
            string currentCharacterId = _characterModelService.CurrentCharacterId;
            
            return ShowCharacterWithCharacterBackground(currentCharacterId, showCharacterType);
        }
        
        public async UniTask ShowCharacterWithCharacterBackground(string characterId, ShowCharacterType showCharacterType = ShowCharacterType.Default)
        {
            ICharacterBackground characterBackground = await _characterModelService.GetCharacterBackground(characterId);
                
            await InitCharacterPlace();
                
            _characterPlace.SetCharacterBackground(characterId, characterBackground);
                
            await ShowCharacter(characterId, showCharacterType);
        }

        public UniTask ShowCurrentCharacterWithSceneBackground(string backgroundId, ShowCharacterType showCharacterType = ShowCharacterType.Default)
        {
            string currentCharacterId = _characterModelService.CurrentCharacterId;

            return ShowCharacterWithSceneBackground(currentCharacterId, backgroundId, showCharacterType);
        }
        
        public UniTask ShowCharacterWithoutBackground(string characterId, ShowCharacterType showCharacterType = ShowCharacterType.Default)
        {
            return ShowCharacterWithSceneBackground(characterId, null, showCharacterType);
        }

        public async UniTask ShowCharacterWithSceneBackground(string characterId, string backgroundId, ShowCharacterType showCharacterType = ShowCharacterType.Default)
        {
            await InitCharacterPlace();

            if (backgroundId != null)
            {
                Sprite sceneBackground = await _characterModelService.GetSceneBackground(backgroundId);
                    
                _characterPlace.SetSceneBackground(sceneBackground);
            }

            await ShowCharacter(characterId, showCharacterType);
        }

        private async UniTask InitCharacterPlace()
        {
            if (_characterPlace == null)
            {
                _characterPlace = await _coreGameObjectManager
                    .GetCoreObjectAsync<ICharacterPlace>(ResourcesProvider.Environment.CharacterPlace);
                
                _characterPlace.SetRenderCamera(_currentCamera);
            }
        }

        private async UniTask ShowCharacter(string characterId, ShowCharacterType showCharacterType)
        {
            CharacterView characterView;
            
            if (showCharacterType == ShowCharacterType.LobbyRoomLeft 
                || showCharacterType == ShowCharacterType.LobbyRoomRight 
                || showCharacterType == ShowCharacterType.LobbyRoomCenter)
            {
                if (_currentDisplayCharacter.CharacterView != null)
                {
                    _currentDisplayCharacter.CharacterView.Deactivate();
                    _currentDisplayCharacter = new CharacterDisplayData();
                }
                
                if (_lobbyDisplayCharacter[showCharacterType].CharacterView != null)
                {
                    if (_lobbyDisplayCharacter[showCharacterType].Id == characterId)
                    {
                        _lobbyDisplayCharacter[showCharacterType].CharacterView.Activate();
                        return;
                    }
                    
                    _lobbyDisplayCharacter[showCharacterType].CharacterView.Deactivate();
                }
                
                CharacterDisplayData characterDisplayData = _lobbyDisplayCharacter[showCharacterType];

                if (characterDisplayData.CharacterView != null)
                {
                    characterDisplayData.CharacterView.Deactivate();
                }
                
                _lobbyDisplayCharacter[showCharacterType] = await _characterModelService.GetNewCharacter(characterId);

                characterView = _lobbyDisplayCharacter[showCharacterType].CharacterView;
            }
            else
            {
                ClearLobbyCharacters();
                
                if (_currentDisplayCharacter.CharacterView != null)
                {
                    _currentDisplayCharacter.CharacterView.Deactivate();
                    _currentDisplayCharacter = new CharacterDisplayData();
                }
            
                _currentDisplayCharacter = await _characterModelService.GetNewCharacter(characterId);
                
                characterView = _currentDisplayCharacter.CharacterView;
            }
            
            _characterPlace.SetCharacter(characterView.transform, characterId, showCharacterType);
            
            characterView.Activate();
            characterView.PlayStandIdle();
        }

        public void SetRenderCamera(Camera camera)
        {
            _currentCamera = camera;
            
            if (_characterPlace != null)
            {
                _characterPlace.SetRenderCamera(_currentCamera);
            }
        }
        
        public void HideLobbyCharacter(ShowCharacterType showCharacterType)
        {
            var character = _lobbyDisplayCharacter[showCharacterType];

            if (character.CharacterView != null)
            {
                character.CharacterView.Deactivate();
            }
        }

        public void Hide()
        {
            _currentDisplayCharacter = default;
            
            if (_characterPlace != null)
            {
                _characterPlace.Deactivate();
            }
        }

        private void ClearLobbyCharacters()
        {
            foreach (var character in _lobbyDisplayCharacter.Values.ToList())
            {
                if (character.CharacterView != null)
                {
                    character.CharacterView.Deactivate();
                }
            }
        }
    }
}