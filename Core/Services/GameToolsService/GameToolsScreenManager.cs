using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using Core.Services.ResourcesLoadService;
using UnityEngine;
using Zenject;

namespace Core.Services.GameToolsService
{
    public class GameToolsScreenManager : IInitializable
    {
        private readonly ICoreScreenManager _coreScreenManager;
        private readonly IGameToolsMenuPresenter _gameToolsMenuPresenter;
        private readonly IGameToolsPresenter _gameToolsPresenter;
        private readonly IGameToolsDebugPresenter _gameToolsDebugPresenter;
        private readonly IGameToolsInfoPresenter _gameToolsInfoPresenter;

        private IGameToolsScreenContainer _container;

        public GameToolsScreenManager(ICoreScreenManager coreScreenManager, IGameToolsMenuPresenter gameToolsMenuPresenter, 
            IGameToolsPresenter gameToolsPresenter, IGameToolsDebugPresenter gameToolsDebugPresenter, IGameToolsInfoPresenter gameToolsInfoPresenter)
        {
            _coreScreenManager = coreScreenManager;
            _gameToolsMenuPresenter = gameToolsMenuPresenter;
            _gameToolsPresenter = gameToolsPresenter;
            _gameToolsDebugPresenter = gameToolsDebugPresenter;
            _gameToolsInfoPresenter = gameToolsInfoPresenter;
        }

        public void Initialize()
        {
            _gameToolsPresenter.ShowView();
            _gameToolsPresenter.OnShowGameToolsMenu += ShowGameToolsMenu;
        }

        private async void ShowGameToolsMenu()
        {
            if (_container == null)
            {
                _container = await _coreScreenManager.ShowCoreAsync<IGameToolsScreenContainer>(ResourcesProvider.UI
                    .GameToolsScreenContainer, false);
                
                _gameToolsMenuPresenter.Initialize(_container.GameToolsMenuView);
                _gameToolsDebugPresenter.Initialize(_container.GameDebugView);
                _gameToolsInfoPresenter.Initialize(_container.GameInfoView);
            }
            
            _gameToolsPresenter.OnShowGameToolsMenu -= ShowGameToolsMenu;
            
            _gameToolsMenuPresenter.OnShowView += ShowGameToolsView;
            _gameToolsMenuPresenter.OnHide += HideGameToolsMenu;
            
            _gameToolsMenuPresenter.ShowView();
            ShowGameToolsView(GameToolsViewType.GameInfo);
        }

        private void HideGameToolsMenu()
        {
            _gameToolsDebugPresenter.HideView();
            _gameToolsInfoPresenter.HideView();
            _gameToolsMenuPresenter.HideView();
            
            _gameToolsPresenter.OnShowGameToolsMenu += ShowGameToolsMenu;
            
            _gameToolsMenuPresenter.OnShowView -= ShowGameToolsView;
            _gameToolsMenuPresenter.OnHide -= HideGameToolsMenu;
        }

        private void ShowGameToolsView(GameToolsViewType gameToolsViewType)
        {
            switch (gameToolsViewType)
            {
                case GameToolsViewType.Debug:
                    _gameToolsDebugPresenter.ShowView();
                    _gameToolsInfoPresenter.HideView();
                    
                    // _gameToolsScreenContainer.SelectTargetView.Hide();
                    // _gameToolsScreenContainer.SelectCardView.Hide();
                    // _gameToolsScreenContainer.GameOptionsView.Hide();
                    break;
                case GameToolsViewType.GameInfo:
                    _gameToolsDebugPresenter.HideView();
                    _gameToolsInfoPresenter.ShowView();
                    
                    // _gameToolsScreenContainer.SelectTargetView.Hide();
                    // _gameToolsScreenContainer.SelectCardView.Hide();
                    // _gameToolsScreenContainer.GameOptionsView.Hide();
                    break;
                case GameToolsViewType.PauseView:
                    //_gameToolsScreenContainer.PauseView.Show();

                    break;
                case GameToolsViewType.SelectTarget:
                    // _gameToolsScreenContainer.GameDebugView.Hide();
                    // _gameToolsScreenContainer.GameInfoView.Hide();
                    // _gameToolsScreenContainer.SelectTargetView.Show();
                    // _gameToolsScreenContainer.SelectCardView.Hide();
                    // _gameToolsScreenContainer.GameOptionsView.Hide();
                    break;
                case GameToolsViewType.SelectCard:
                    // _gameToolsScreenContainer.GameDebugView.Hide();
                    // _gameToolsScreenContainer.GameInfoView.Hide();
                    // _gameToolsScreenContainer.SelectTargetView.Hide();
                    // _gameToolsScreenContainer.SelectCardView.Show();
                    // _gameToolsScreenContainer.GameOptionsView.Hide();
                    break;
                case GameToolsViewType.GameOptions:
                    // _gameToolsScreenContainer.GameDebugView.Hide();
                    // _gameToolsScreenContainer.GameInfoView.Hide();
                    // _gameToolsScreenContainer.SelectTargetView.Hide();
                    // _gameToolsScreenContainer.SelectCardView.Hide();
                    // _gameToolsScreenContainer.GameOptionsView.Show();
                    break;
            }
        }
    }
}