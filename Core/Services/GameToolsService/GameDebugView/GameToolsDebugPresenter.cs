using System;
using Core.Services.GameToolsService.Interfaces;
using UnityEngine;

namespace Core.Services.GameToolsService.GameDebugView
{
    public class GameToolsDebugPresenter : IGameToolsDebugPresenter
    {
        private string _debugMessage;
        
        private IGameDebugView _gameDebugView;

        public void Initialize(IGameDebugView view)
        {
            _gameDebugView = view;
        }

        public void ShowView()
        {
            _gameDebugView.Clear();
            
            _gameDebugView.SetText(_debugMessage);
            
            _gameDebugView.Show();
            _gameDebugView.OnCopy += CopyDebugMessage;
        }

        public void AddDebugMessage(string value)
        {
            _debugMessage += ($"[{DateTime.Now.ToString("HH:mm")}]: {value}" + "\n\n");
            
            if (_gameDebugView != null && _gameDebugView.IsShow)
            {
                _gameDebugView.Clear();
                _gameDebugView.SetText(_debugMessage);
            }
        }

        public void HideView()
        {
            _gameDebugView.OnCopy -= CopyDebugMessage;
            _gameDebugView.Hide();
        }
        
        private void CopyDebugMessage()
        {
            GUIUtility.systemCopyBuffer = _debugMessage;
        }
    }
}