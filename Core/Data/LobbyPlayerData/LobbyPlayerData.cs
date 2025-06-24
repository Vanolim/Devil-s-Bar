using Views.Player;

namespace Core.Data.LobbyPlayerData
{
    public struct LobbyPlayerData
    {
        public readonly int GameBoardPlaceIndex;
        public readonly int GameBoardLocalPlaceIndex;
        public readonly string Name;
        public readonly string Id;
        public readonly CharacterView View;

        public LobbyPlayerData(int gameBoardPlaceIndex, string name, string id, CharacterView view)
        {
            GameBoardPlaceIndex = gameBoardPlaceIndex;
            Name = name;
            Id = id;
            View = view;
            GameBoardLocalPlaceIndex = default;
        }
        
        public LobbyPlayerData(string name, string id, int gameBoardPlaceIndex, int gameBoardLocalPlaceIndex, CharacterView view)
        {
            Name = name;
            Id = id;
            GameBoardPlaceIndex = gameBoardPlaceIndex;
            GameBoardLocalPlaceIndex = gameBoardLocalPlaceIndex;
            View = view;
        }
    }
}