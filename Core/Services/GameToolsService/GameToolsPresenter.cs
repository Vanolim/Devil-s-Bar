using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using Core.Services.ResourcesLoadService;

namespace Core.Services.GameToolsService
{
    public class GameToolsPresenter : IGameToolsPresenter
    {
        private readonly ICoreScreenManager _coreScreenManager;

        private IGameToolsView _view;
        
        public event Action OnShowGameToolsMenu;

        public GameToolsPresenter(ICoreScreenManager coreScreenManager)
        {
            _coreScreenManager = coreScreenManager;
        }
        
        public async void ShowView()
        {
            _view = await _coreScreenManager.ShowCoreAsync<IGameToolsView>(ResourcesProvider.UI.GameToolsView);
            
            _view.OnShowGameToolsMenu += OnShowGameToolsMenu;
        }

        public void HideView()
        {
            if (_view != null)
            {
                _view.OnShowGameToolsMenu -= OnShowGameToolsMenu;
                _view.Hide();
            }
        }
    }
}