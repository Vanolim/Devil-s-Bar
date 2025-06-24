using System;

namespace Hub.PlayerProfile.Interfaces
{
    public interface IPlayerProfileToolsView
    {
        public void Initialize(Action copyButtonEvent, Action changeButtonEvent);
    }
}