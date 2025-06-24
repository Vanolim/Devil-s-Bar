using System;
using Cysharp.Threading.Tasks;

namespace Hub.HubMenu.Interfaces
{
    public interface IHubMenuPresenter
    {
        event Action OnPlay;
        event Action OnСustomize;
        event Action OnSettings;
        event Action OnShop;
        event Action OnOptions;
        
        UniTask ShowView();
        void HideView();
        UniTask HideMenuWithAnimation();
    }
}