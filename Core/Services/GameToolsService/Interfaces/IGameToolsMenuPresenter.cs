using System;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsMenuPresenter
    {
        event Action<GameToolsViewType> OnShowView;
        event Action OnHide;
        
        void Initialize(IGameToolsMenuView view);
        void ShowView();
        
        void HideView();
    }
}