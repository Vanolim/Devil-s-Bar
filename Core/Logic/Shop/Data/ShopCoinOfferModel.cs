using Core.Logic.Shop.Infrastructure;
using Core.Logic.Shop.Interfaces;

namespace Core.Logic.Shop.Data
{
    public class ShopCoinOfferModel : IShopCoinOfferModel
    {
        public bool IsActive { get; }
        public string CoinOfferId { get; }
        public int CoinValue { get; }
        public float Price { get; }
        
        public OfferNoticeType NoticeType { get; private set; }
        
        public ShopCoinOfferModel(bool isActive, string coinOfferId, int coinValue, float price, 
            OfferNoticeType noticeType)
        {
            IsActive = isActive;
            CoinOfferId = coinOfferId;
            CoinValue = coinValue;
            Price = price;
            NoticeType = noticeType;
        }

        public void ChangeNotice(OfferNoticeType newNotice)
        {
            NoticeType = newNotice;
        }
    }
}