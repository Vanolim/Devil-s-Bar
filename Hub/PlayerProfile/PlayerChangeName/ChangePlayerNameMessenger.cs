using Hub.PlayerProfile.Interfaces;
using Hub.PlayerProfile.PlayerChangeName.PlayerNameValidator;

namespace Hub.PlayerProfile.PlayerChangeName
{
    public class ChangePlayerNameMessenger : IChangePlayerNameMessenger
    {
        private const string ErrorMessageLongName = "It’s not rocket science: 3–12 letters or numbers. You got this.";
        private const string ErrorMessageShortName = "It’s not rocket science: 3–12 letters or numbers. You got this.";
        private const string ErrorMessageUncensoredName = "Congratulations, you’ve invented swearing. Now pick a real name.";
        
        public void SendMessage(PlayerNameErrorValidateMessage errorCode, IPlayerProfileChangeNameView displayer)
        {
            switch (errorCode)
            {
                case PlayerNameErrorValidateMessage.Long:
                    displayer.SwitchVisibilityErrorMessage(isVisibility: true);
                    displayer.SetErrorMessage(ErrorMessageLongName);
                    break;
                case PlayerNameErrorValidateMessage.Short:
                    displayer.SwitchVisibilityErrorMessage(isVisibility: true);
                    displayer.SetErrorMessage(ErrorMessageShortName);
                    break;
                case PlayerNameErrorValidateMessage.Profanity:
                    displayer.SwitchVisibilityErrorMessage(isVisibility: true);
                    displayer.SetErrorMessage(ErrorMessageUncensoredName);
                    break;
              default:
                  displayer.SwitchVisibilityErrorMessage(isVisibility: false);
                  break;
            }
        }
    }
}