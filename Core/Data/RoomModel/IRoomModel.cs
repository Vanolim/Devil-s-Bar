using System.Collections.Generic;

namespace Core.Data.RoomModel
{
    public interface IRoomModel
    {
        string RoomName { get; }
        RoomType RoomType { get; }
        int Bet { get; }

        IReadOnlyCollection<string> Players { get; }
        IReadOnlyCollection<string> Characters { get; }
        IReadOnlyCollection<bool> ReadyPlayers { get; }
        
        void AddPlayer(string playerId, string characterId);
        void ChangeCharacter(string playerId, string characterId);
        void RemovePlayer(string playerId);
        void AddReadyPlayer(string playerId);
        string GetPlayerCharacter(string playerId);
        bool GetPlayerReadyState(string playerId);

        int GetPlayersCount();
    }
}