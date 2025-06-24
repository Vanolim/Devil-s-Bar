using System;

namespace Hub.HubScreenManager
{
    public interface IHubScreenManager
    {
        event Action OnPlay;
        void Activate();
        void Deactivate();
    }
}