using System.Collections.Generic;
using UnityEngine;

namespace Core.Logic.Shop.Data
{
    [CreateAssetMenu(fileName = "CoinsOfferData", menuName = "ScriptableObjects/CoinsOfferData")]
    public class CoinOffersData : ScriptableObject
    {
        [SerializeField]
        private CoinOfferData[] _coinOffers;
        
        public IReadOnlyCollection<CoinOfferData> CoinOffers => _coinOffers;
    }
}