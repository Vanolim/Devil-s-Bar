using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Hub.PlayerProfile.Data;
using Hub.PlayerProfile.Interfaces;
using UnityEngine;

namespace Hub.PlayerProfile
{
    public class PlayerManualProfilePresenter : IPlayerProfilePresenter
    {
        private readonly ISceneScreenManager _sceneScreenManager;
        private readonly IChangeNamePresenter _changeNamePresenter;
        private readonly IPlayerProfileService _playerProfileService;

        private PlayerProfileDisplayData _playerProfileDisplayData;
        private IPlayerManualProfileView _view;

        public PlayerManualProfilePresenter(IChangeNamePresenter changeNamePresenter, 
            ISceneScreenManager sceneScreenManager, IPlayerProfileService playerProfileService)
        {
            _sceneScreenManager = sceneScreenManager;
            _changeNamePresenter = changeNamePresenter;
            _playerProfileService = playerProfileService;
        }

        public async void ShowView()
        {
            _view = await _sceneScreenManager
                .ShowAsync<IPlayerManualProfileView>(ResourcesProvider.UI.ManualPlayerProfileView);
            
            _view.PlayerProfileToolsView.Initialize(CopyName, OpenChangingNameView);
            SetPlayerProfileDisplayData();
            
            _playerProfileService.OnPlayerProfileDataUpdated += SetPlayerProfileDisplayData;
        }

        public void HideView()
        {
            if (_view != null)
            {
                _view.Hide();
            }

            _playerProfileService.OnPlayerProfileDataUpdated -= SetPlayerProfileDisplayData;
        }
        
        private void SetPlayerProfileDisplayData()
        {
            _playerProfileDisplayData = _playerProfileService.GetPlayerProfileDisplayData();
            
            if (_view != null)
            {
                _view.PlayerProfileView.SetDisplayedData(_playerProfileDisplayData);
            }
        }

        private void CopyName()
        {
            GUIUtility.systemCopyBuffer = $"{_playerProfileDisplayData.Name}#{_playerProfileDisplayData.NameDiscriminator}";
        }

        private void OpenChangingNameView()
        {
            _changeNamePresenter.OpenView();
        }
    }
}