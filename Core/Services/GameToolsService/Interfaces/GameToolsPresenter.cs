using System;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsPresenter
    {
        event Action OnShowGameToolsMenu;
        void ShowView();
        void HideView();
    }
}