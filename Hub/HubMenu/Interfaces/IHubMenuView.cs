using System;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;

namespace Hub.HubMenu.Interfaces
{
    public interface IHubMenuView : IBaseScreen
    {
        void Initialize(Action customizeButtonEvent, Action settingsButtonEvent,
            Action shopButtonEvent, Action optionsButtonEvent, Action playButtonEvent);

        UniTask HideWithAnimation();
    }
}