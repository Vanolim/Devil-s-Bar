using Hub.PlayerProfile.PlayerChangeName.PlayerNameValidator;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IChangePlayerNameMessenger
    {
        void SendMessage(PlayerNameErrorValidateMessage errorCode, IPlayerProfileChangeNameView displayer);
    }
}