using System.Collections.Generic;
using System.Linq;

namespace Core.Data.RoomModel
{
    public class RoomModel : IRoomModel
    {
        private readonly string[] _players;
        private readonly string[] _characters;
        private readonly bool[] _readyPlayers;
        
        public string RoomName { get; }
        public RoomType RoomType { get; }
        public int Bet { get; }
        
        public IReadOnlyCollection<string> Players => _players;
        public IReadOnlyCollection<string> Characters => _characters;
        public IReadOnlyCollection<bool> ReadyPlayers => _readyPlayers;
        
        public RoomModel(string roomName, RoomType roomType, int bet, string[] playersId, string[] charactersId, bool[] readyCharacters)
        {
            RoomName = roomName;
            RoomType = roomType;
            Bet = bet;

            _players = playersId;
            _characters = charactersId;
            _readyPlayers = readyCharacters;
        }
        
        public RoomModel(string roomName, RoomType roomType, int bet, string hostPlayerId, string hostCharacterId)
        {
            RoomName = roomName;
            RoomType = roomType;
            Bet = bet;

            _players = new[] { hostPlayerId, "", ""};
            _characters = new[] { hostCharacterId, "", "" };
            _readyPlayers = new[] { false, false, false };
        }

        public void AddPlayer(string playerId, string characterId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == "")
                {
                    _players[i] = playerId;
                    _characters[i] = characterId;
                    _readyPlayers[i] = false;
                    return;
                }
            }
        }

        public void ChangeCharacter(string playerId, string characterId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == playerId)
                {
                    _characters[i] = characterId;
                    return;
                }
            }
        }

        public void RemovePlayer(string playerId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == playerId)
                {
                    _players[i] = "";
                    _characters[i] = "";
                    _readyPlayers[i] = false;
                    return;
                }
            }
        }

        public void AddReadyPlayer(string playerId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == playerId)
                {
                    _readyPlayers[i] = true;
                    return;
                }
            }
        }

        public string GetPlayerCharacter(string playerId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == playerId)
                {
                    return _characters[i];
                }
            }

            return null;
        }

        public bool GetPlayerReadyState(string playerId)
        {
            for (int i = 0; i < _players.Length; i++)
            {
                if (_players[i] == playerId)
                {
                    return _readyPlayers[i];
                }
            }
            
            return false;
        }

        public int GetPlayersCount()
        {
            int value = 0;
            
            for (int i = 0; i < _players.Count(); i++)
            {
                if (_players[i] != "")
                {
                    value++;
                }
            }

            return value;
        }
    }
}