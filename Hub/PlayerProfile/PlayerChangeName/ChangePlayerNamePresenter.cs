using Core.Managers.ScreenManager;
using Core.Services.ResourcesLoadService;
using Hub.PlayerProfile.Interfaces;
using Hub.PlayerProfile.PlayerChangeName.PlayerNameValidator;

namespace Hub.PlayerProfile.PlayerChangeName
{
    public class ChangePlayerNamePresenter : IChangeNamePresenter
    {
        private readonly ISceneScreenManager _sceneScreenManager;
        private readonly IChangePlayerNameMessenger _changePlayerNameMessenger;
        private readonly IPlayerProfileService _playerProfileService;
        private readonly PlayerNameValidator.PlayerNameValidator _playerNameValidator;

        private IPlayerProfileChangeNameView _view;
        private string _newPlayerName;
        private bool _isNewNameValidate;
        
        public ChangePlayerNamePresenter(IPlayerProfileService playerProfileService, ISceneScreenManager sceneScreenManager, 
            IChangePlayerNameMessenger changePlayerNameMessenger)
        {
            _playerProfileService = playerProfileService;
            _sceneScreenManager = sceneScreenManager;
            _changePlayerNameMessenger = changePlayerNameMessenger;
            
            _playerNameValidator = new PlayerNameValidator.PlayerNameValidator();
        }

        public async void OpenView()
        {
            _view = await _sceneScreenManager
                .ShowAsync<IPlayerProfileChangeNameView>(ResourcesProvider.UI.ChangeNameView);
            
            _view.Initialize(CheckNewName, HideView, ChangeName);

            string displayPlayerName = _playerProfileService.GetPlayerName();
            _view.SetDisplayName(displayPlayerName);
            
            _changePlayerNameMessenger.SendMessage(PlayerNameErrorValidateMessage.None, _view);

            _isNewNameValidate = false;
        }

        public void HideView()
        {
            if (_view != null)
            {
                _view.Hide();
            }
        }

        private void CheckNewName(string newName)
        {
            if (_playerNameValidator.ValidateNewName(newName, out PlayerNameErrorValidateMessage errorValidateMessage))
            {
                _newPlayerName = newName.ToUpper();
                _changePlayerNameMessenger.SendMessage(PlayerNameErrorValidateMessage.None, _view);

                _view.BlockAcceptButton(isBlock: false);
                _isNewNameValidate = true;
            }
            else
            {
                _view.BlockAcceptButton(isBlock: true);
                _changePlayerNameMessenger.SendMessage(errorValidateMessage, _view);
                _isNewNameValidate = false;
            }
        }

        private void ChangeName()
        {
            if (_isNewNameValidate)
            {
                _playerProfileService.ChangePlayerName(_newPlayerName);
                HideView();
            }
        }
    }
}