using System;
using Core.Managers.ScreenManager;

namespace Core.Services.GameToolsService.Interfaces
{
    public interface IGameDebugView : IBaseScreen
    {
        event Action OnCopy;
        bool IsShow { get; }
        void SetText(string value);
        void Clear();
    }
}