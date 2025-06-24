using System;
using Core.Managers.ScreenManager;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IPlayerProfileChangeNameView : IBaseScreen
    {
        void Initialize(Action<string> nameInputFieldChanged, Action canselButtonEvent,
            Action acceptButtonEvent);

        void SetDisplayName(string newName);
        void BlockAcceptButton(bool isBlock);
        void SetErrorMessage(string message);
        void SwitchVisibilityErrorMessage(bool isVisibility);
        void Hide();
    }
}