using System;

namespace Core.Logic.Wallet.Interfaces
{
    public interface IWallet
    {
        event Action OnOpenShop;
        
        void AddValue(int addValue);
        bool TryBuy(int value);
    }
}