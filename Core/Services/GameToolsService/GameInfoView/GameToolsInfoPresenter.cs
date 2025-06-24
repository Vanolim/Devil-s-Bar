using System.Collections.Generic;
using System.Linq;
using Core.Data.LobbyPlayerData;
using Core.Services.GameToolsService.Interfaces;

namespace Core.Services.GameToolsService.GameInfoView
{
    public class GameToolsInfoPresenter : IGameToolsInfoPresenter
    {
        private readonly Dictionary<int, LobbyPlayerData> _playersInfo = new();
        
        private IGameInfoView _gameInfoView;
        
        private string _region;
        private (string, bool, bool) _roomInfo;
        private string _gameVersion;
        
        public void Initialize(IGameInfoView gameInfoView)
        {
            _gameInfoView = gameInfoView;
        }

        public void ShowView()
        {
            foreach (var playerInfo in _playersInfo)
            {
                var playerData = playerInfo.Value;

                string skin;
                if (playerData.View == null)
                {
                    skin = "None";
                }
                else
                {
                    skin = playerData.View.gameObject.name;
                }
                
                _gameInfoView.SetPlayerInfo(playerData.Name, playerData.Id, skin, playerInfo.Key);
            }
            
            _gameInfoView.SetRegion(_region);
            _gameInfoView.SetRoomInfo(_roomInfo.Item1, _roomInfo.Item2, _roomInfo.Item3);
            _gameInfoView.SetGameVersion(_gameVersion);
            
            _gameInfoView.Show();
        }

        public void SetPlayerInfo(int playerIndex, LobbyPlayerData lobbyPlayerData)
        {
            var playerInfoKey = _playersInfo.FirstOrDefault(x => x.Key == playerIndex).Key;
            if (playerInfoKey == default)
            {
                _playersInfo.Add(playerIndex, lobbyPlayerData);
            }
            else
            {
                _playersInfo[playerInfoKey] = lobbyPlayerData;
            }

            if (_gameInfoView != null && _gameInfoView.IsShow)
            {
                _gameInfoView.SetPlayerInfo(lobbyPlayerData.Name, lobbyPlayerData.Id, lobbyPlayerData.View.gameObject.name, 
                    playerIndex);
            }
        }

        public void SetDefaultPlayerInfo(int index)
        {
            SetPlayerInfo(index, default);
        }

        public void SetRegion(string region)
        {
            _region = region;
            
            if (_gameInfoView != null && _gameInfoView.IsShow)
            {
                _gameInfoView.SetRegion(_region);
            }
        }

        public void SetRoomInfo(string name, bool isOpen, bool isVisible)
        {
            _roomInfo = new(name, isOpen, isVisible);

            if (_gameInfoView != null && _gameInfoView.IsShow)
            {
                _gameInfoView.SetRoomInfo(_roomInfo.Item1, _roomInfo.Item2, _roomInfo.Item3);
            }
        }

        public void SetGameVersion(string gameVersion)
        {
            _gameVersion = gameVersion;
            
            if (_gameInfoView != null && _gameInfoView.IsShow)
            {
                _gameInfoView.SetGameVersion(_gameVersion);
            }
        }

        public void SetDefaultValue()
        {
            _gameInfoView.SetDefaultValue();
        }

        public void HideView()
        {
            _gameInfoView.Hide();
        }
    }
}