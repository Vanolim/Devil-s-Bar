using System;

namespace Core.Logic.Wallet.Interfaces
{
    public interface IWalletService
    {
        event Action OnValueChanged;
        
        int CurrentHardValue { get; }

        void OpenShop();
    }
}