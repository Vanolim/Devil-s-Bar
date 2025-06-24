using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using Core.Services.ResourcesLoadService;

namespace Core.Services.GameToolsService
{
    public class GameToolsMenuPresenter : IGameToolsMenuPresenter
    {
        private readonly ICoreScreenManager _coreScreenManager;

        private IGameToolsMenuView _view;
        
        public event Action<GameToolsViewType> OnShowView;
        public event Action OnHide;

        public void Initialize(IGameToolsMenuView view)
        {
            _view = view;
        }

        public void ShowView()
        {
            _view.Show();
            _view.Initialize(ShowDebugViewEvent, ShowInfoViewEvent, OnHide);
        }

        private void ShowDebugViewEvent() => OnShowView?.Invoke(GameToolsViewType.Debug);
        
        private void ShowInfoViewEvent() => OnShowView?.Invoke(GameToolsViewType.GameInfo);
        
        public void HideView()
        {
            if (_view != null)
            {
                _view.Hide();
            }
        }
    }
}