using System;
using Core.Managers.ScreenManager;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameToolsView : IBaseScreen
    {
        event Action OnShowGameToolsMenu;
    }
}