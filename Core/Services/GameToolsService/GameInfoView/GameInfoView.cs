using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Services.GameToolsService.GameInfoView
{
    public class GameInfoView : MonoBehaviour, IGameInfoView
    {
        [SerializeField] private TMP_Text _playerName1;
        [SerializeField] private TMP_Text _playerId1;
        [SerializeField] private TMP_Text _playerSkin1;
        
        [SerializeField] private TMP_Text _playerName2;
        [SerializeField] private TMP_Text _playerId2;
        [SerializeField] private TMP_Text _playerSkin2;
        
        [SerializeField] private TMP_Text _playerName3;
        [SerializeField] private TMP_Text _playerId3;
        [SerializeField] private TMP_Text _playerSkin3;
        
        [SerializeField] private TMP_Text _region;
        [SerializeField] private TMP_Text _roomName;
        [SerializeField] private Toggle _isRoomOpen;
        [SerializeField] private Toggle _isRoomVisible;
        
        [SerializeField] private TMP_Text _gameVersion;
        
        public bool IsShow { get; private set; }
        
        public event Action<IBaseScreen> OnDestroyed;

        public void Show()
        {
            IsShow = true;
            gameObject.SetActive(true);
        }

        public void SetPlayerInfo(string name, string id, string skin, int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    _playerName1.text = "Name: " + name;
                    _playerId1.text = "Id: " + id;
                    _playerSkin1.text = "Skin: " + skin;
                    break;
                case 2:
                    _playerName2.text = "Name: " + name;
                    _playerId2.text = "Id: " + id;
                    _playerSkin2.text = "Skin: " + skin;
                    break;
                case 3:
                    _playerName3.text = "Name: " + name;
                    _playerId3.text = "Id: " + id;
                    _playerSkin3.text = "Skin: " + skin;
                    break;
            }
        }

        public void SetRegion(string region)
        {
            _region.text = "Region: " + region;
        }

        public void SetRoomInfo(string name, bool isOpen, bool isVisible)
        {
            _roomName.text = "Room name: " + name;
            _isRoomOpen.isOn = isOpen;
            _isRoomVisible.isOn = isVisible;
        }

        public void SetGameVersion(string gameVersion)
        {
            _gameVersion.text = "Game version: " + gameVersion;
        }

        public void SetDefaultValue()
        {
            SetPlayerInfo("None", "None", "None",1);
            SetPlayerInfo("None", "None", "None",2);
            SetPlayerInfo("None", "None", "None",3);
            SetRegion("None");
            SetRoomInfo("None", false, false);
            SetGameVersion("None");
        }

        public void Hide()
        {
            IsShow = false;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }
    }
}