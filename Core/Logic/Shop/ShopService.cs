using System;
using System.Linq;
using Core.Logic.Shop.Interfaces;
using Core.Logic.Wallet.Interfaces;
using Core.Services.PhotonServices.Interfaces;
using Core.Services.SaveLoadService;
using Cysharp.Threading.Tasks;

namespace Core.Logic.Shop
{
    public class ShopService : IShopService
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IShopOffersDataAdapter _shopCoinOffersDataAdapter;
        private readonly IWallet _wallet;

        public event Action OnCoinOffersUpdated;

        public ShopService(ISaveLoadService saveLoadService, IShopOffersDataAdapter shopCoinOffersDataAdapter, IWallet wallet)
        {
            _saveLoadService = saveLoadService;
            _shopCoinOffersDataAdapter = shopCoinOffersDataAdapter;
            _wallet = wallet;
        }

        public UniTask<IShopCoinOfferModel> GetCoinOfferData(string coinOfferId)
        {
            return _shopCoinOffersDataAdapter.GetCoinOfferData(coinOfferId);
        }

        public async UniTask BuyCoinOffer(string coinOfferId)
        {
            var offerData = await GetCoinOfferData(coinOfferId);
            
            _wallet.AddValue(offerData.CoinValue);

            var currentSaveData = _saveLoadService.CurrentData;
            var currentSaveDataPurchases = currentSaveData.Purchases;

            string[] newPurchases;

            if (currentSaveData.Purchases.Any())
            {
                newPurchases = new string[currentSaveDataPurchases.Length + 1];

                for (int i = 0; i < currentSaveDataPurchases.Length; i++)
                {
                    newPurchases[i] = currentSaveDataPurchases[i];
                }

                newPurchases[^1] = coinOfferId;
            }
            else
            {
                newPurchases = new[] { coinOfferId };
            }

            currentSaveData.Purchases = newPurchases;
            
            _saveLoadService.SaveData(currentSaveData);
        }
    }
}