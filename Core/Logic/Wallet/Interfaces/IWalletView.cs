using System;
using Core.Managers.ScreenManager;

namespace Core.Logic.Wallet.Interfaces
{
    public interface IWalletView : IBaseScreen
    {
        void Initialize(Action walletButtonClicked);
        
        void SetValue(string value);
    }
}