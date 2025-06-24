using System;
using Core.Logic.Wallet.Interfaces;
using Core.Services.SaveLoadService;

namespace Core.Logic.Wallet
{
    public class Wallet : IWallet, IWalletService
    {
        private readonly ISaveLoadService _saveLoadService;
        
        public int CurrentHardValue => (int)_saveLoadService.CurrentData.HardCurrency;

        public event Action OnOpenShop;
        public event Action OnValueChanged;

        public Wallet(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }
        
        public void AddValue(int addValue)
        {
            var currenData = _saveLoadService.CurrentData;
            
            currenData.HardCurrency += addValue;
            _saveLoadService.SaveData(currenData);
            
            OnValueChanged?.Invoke();
        }

        public bool TryBuy(int value)
        {
            var currenData = _saveLoadService.CurrentData;

            if (currenData.HardCurrency < value)
            {
                return false;
            }

            currenData.HardCurrency -= value;
            _saveLoadService.SaveData(currenData);
                
            OnValueChanged?.Invoke();

            return true;
        }

        public void OpenShop()
        {
            OnOpenShop?.Invoke();
        }
    }
}