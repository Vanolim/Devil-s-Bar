namespace Core.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        SaveData CurrentData { get; }
        void SaveData(SaveData newData);

        void LoadData();
    }
}