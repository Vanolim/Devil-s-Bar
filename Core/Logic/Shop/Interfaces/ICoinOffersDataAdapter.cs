using Core.Logic.Shop.Data;

namespace Core.Logic.Shop.Interfaces
{
    public interface ICoinOffersDataAdapter
    {
        CoinOfferData GetCoinOfferData(string coinOfferId);
    }
}