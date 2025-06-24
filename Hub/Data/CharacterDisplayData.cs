using Views.Player;

namespace Hub.Data
{
    public struct CharacterDisplayData
    {
        public string Id { get; }
        public CharacterView CharacterView { get; }

        public CharacterDisplayData(string id, CharacterView characterView)
        {
            Id = id;
            CharacterView = characterView;
        }
    }
}