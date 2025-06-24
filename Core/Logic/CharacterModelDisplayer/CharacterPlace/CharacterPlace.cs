using System;
using Core.Logic.CharacterModelDisplayer.Infrastructure;
using Core.Logic.CharacterModelDisplayer.Interfaces;
using Core.Managers.GameObjectManager;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Logic.CharacterModelDisplayer.CharacterPlace
{
    public class CharacterPlace : MonoBehaviour, ICharacterPlace
    {
        [SerializeField]
        private SelectedCharacterPlaceSpawnPointsData.SelectedCharacterPlaceSpawnPointsData _selectedCharacterPlaceSpawnPointsData;

        [SerializeField]
        private Canvas _sceneBackgroundCanvas;

        [SerializeField]
        private Image _sceneBackgroundImage;

        [SerializeField]
        private GameObject _sceneLights;

        [SerializeField]
        private Transform _characterBackgroundParent;
        
        public event Action<IBaseGameObject> OnDestroyed;
        
        public void SetCharacter(Transform character, string characterId, ShowCharacterType showCharacterType)
        {
            Transform spawnPoint;

            switch (showCharacterType)
            {
                case ShowCharacterType.Right:
                    spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetRightSpawnPoint(characterId);
                    break;
                case ShowCharacterType.LobbyRoomLeft:
                    spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetLeftLobbySpawnPoint(characterId);
                    break;
                case ShowCharacterType.LobbyRoomCenter:
                    spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetCenterLobbySpawnPoint(characterId);
                    break;
                case ShowCharacterType.LobbyRoomRight:
                    spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetRightLobbySpawnPoint(characterId);
                    break;
                default:
                    spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetSpawnPoint(characterId);
                    break;
            }
            
            character.transform.position = spawnPoint.position;
            character.transform.rotation = spawnPoint.rotation;
        }

        public void SetRenderCamera(Camera camera)
        {
            _sceneBackgroundCanvas.worldCamera = camera;
        }

        public void SetSceneBackground(Sprite sprite)
        {
            _characterBackgroundParent.gameObject.SetActive(false);
            
            _sceneLights.gameObject.SetActive(true);
            
            _sceneBackgroundImage.sprite = sprite;
            _sceneBackgroundCanvas.gameObject.SetActive(true);
        }

        public void SetCharacterBackground(string characterId, ICharacterBackground background)
        {
            _sceneBackgroundCanvas.gameObject.SetActive(false);
            _sceneLights.gameObject.SetActive(false);
            
            var allBackgroundSpawnPoint = _selectedCharacterPlaceSpawnPointsData.GetAllCharacterBackgroundSpawnPoints();
            foreach (var backgroundSpawnPoint in allBackgroundSpawnPoint)
            {
                backgroundSpawnPoint.gameObject.SetActive(false);
            }
            
            Transform spawnPoint = _selectedCharacterPlaceSpawnPointsData.GetCharacterBackgroundSpawnPoint(characterId);
            spawnPoint.gameObject.SetActive(true);
            
            background.SetParent(spawnPoint);
            background.Activate();
            
            _characterBackgroundParent.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            _sceneBackgroundCanvas.gameObject.SetActive(false);
            _characterBackgroundParent.gameObject.SetActive(false);
            _sceneLights.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}