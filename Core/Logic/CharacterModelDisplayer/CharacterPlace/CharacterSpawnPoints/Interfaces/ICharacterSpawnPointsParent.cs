namespace Core.Logic.CharacterModelDisplayer.CharacterPlace.CharacterSpawnPoints.Interfaces
{
    public interface ICharacterSpawnPointsParent
    {
        CharacterSpawnPointsType PointsType { get; }
        
        ICharacterSpawnPoint GetSpawnPoint(string characterId);
        
        void Activate();
        void Deactivate();
        void DeactivatePoints();
    }
}