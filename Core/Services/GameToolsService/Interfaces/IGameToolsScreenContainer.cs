using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.View;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsScreenContainer : IBaseScreen
    {
        GameToolsMenuView GameToolsMenuView { get; }
        GameDebugView.GameDebugView GameDebugView { get; }
        GameInfoView.GameInfoView GameInfoView { get; }
        PauseView PauseView { get; }
        SelectTargetView SelectTargetView { get; }
        SelectCardView SelectCardView { get; }
        GameOptionsView GameOptionsView { get; }
    }
}