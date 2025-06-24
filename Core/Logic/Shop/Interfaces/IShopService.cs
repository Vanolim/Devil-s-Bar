using System;
using Core.Services.PhotonServices.Interfaces;
using Cysharp.Threading.Tasks;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopService
    {
        event Action OnCoinOffersUpdated;
        
        UniTask<IShopCoinOfferModel> GetCoinOfferData(string coinOfferId);
        UniTask BuyCoinOffer(string coinOfferId);
    }
}