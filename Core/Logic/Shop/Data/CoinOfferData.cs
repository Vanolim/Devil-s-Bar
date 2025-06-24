using System;
using Core.Logic.Shop.Infrastructure;
using UnityEngine;

namespace Core.Logic.Shop.Data
{
    [Serializable]
    public class CoinOfferData
    {
        [SerializeField]
        private string _offerId;

        [SerializeField]
        private int _coinValue;

        [SerializeField]
        private float _price;
        
        [SerializeField]
        private OfferNoticeType _noticeType;
        
        [SerializeField]
        private bool _offerIsActive;
        
        public string OfferId => _offerId;
        public int CoinValue => _coinValue;
        public float Price => _price;
        public OfferNoticeType NoticeType => _noticeType;
        public bool OfferIsActive => _offerIsActive;
    }
}