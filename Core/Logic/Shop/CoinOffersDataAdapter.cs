using System.Linq;
using Core.Logic.Shop.Data;
using Core.Logic.Shop.Interfaces;

namespace Core.Logic.Shop
{
    public class CoinOffersDataAdapter : ICoinOffersDataAdapter
    {
        private readonly CoinOffersData _coinOffersData;

        public CoinOffersDataAdapter(CoinOffersData coinOffersData)
        {
            _coinOffersData = coinOffersData;
        }

        public CoinOfferData GetCoinOfferData(string coinOfferId)
        {
            return _coinOffersData.CoinOffers.First(x => x.OfferId == coinOfferId);
        }
    }
}