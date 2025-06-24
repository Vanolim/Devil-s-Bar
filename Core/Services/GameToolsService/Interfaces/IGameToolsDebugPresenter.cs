namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsDebugPresenter
    {
        void Initialize(IGameDebugView view);
        void ShowView();
        void AddDebugMessage(string value);
        void HideView();
    }
}