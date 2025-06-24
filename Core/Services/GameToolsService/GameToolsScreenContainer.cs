using System;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService.Interfaces;
using Core.Services.GameToolsService.View;
using UnityEngine;

namespace Core.Services.GameToolsService
{
    public class GameToolsScreenContainer : MonoBehaviour, IGameToolsScreenContainer
    {
        [SerializeField] 
        private GameToolsMenuView _gameToolsView;
        
        [SerializeField] 
        private GameDebugView.GameDebugView _gameDebugView;
        
        [SerializeField] 
        private GameInfoView.GameInfoView _gameInfoView;
        
        [SerializeField] 
        private PauseView _pauseView;
        
        [SerializeField] 
        private SelectTargetView _selectTargetView;
        
        [SerializeField] 
        private SelectCardView _selectCardView;
        
        [SerializeField] 
        private GameOptionsView _gameOptionsView;
        
        public GameToolsMenuView GameToolsMenuView => _gameToolsView;
        public GameDebugView.GameDebugView GameDebugView => _gameDebugView;
        public GameInfoView.GameInfoView GameInfoView => _gameInfoView;
        public PauseView PauseView => _pauseView;
        public SelectTargetView SelectTargetView => _selectTargetView;
        public SelectCardView SelectCardView => _selectCardView;
        public GameOptionsView GameOptionsView => _gameOptionsView;
        
        public event Action<IBaseScreen> OnDestroyed;
        public void Show()
        {
            //throw new NotImplementedException();
        }

        public void Hide()
        {
            //throw new NotImplementedException();
        }
    }
}