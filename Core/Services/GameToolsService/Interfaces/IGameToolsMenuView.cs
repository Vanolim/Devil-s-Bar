using System;
using Core.Managers.ScreenManager;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsMenuView : IBaseScreen
    {
        void Initialize(Action showDebug, Action showInfo, Action hide);
    }
}