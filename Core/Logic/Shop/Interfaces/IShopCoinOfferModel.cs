using Core.Logic.Shop.Infrastructure;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopCoinOfferModel
    {
        public bool IsActive { get; }
        public string CoinOfferId { get; }
        public int CoinValue { get; }
        public float Price { get; }
        public OfferNoticeType NoticeType { get; }

        void ChangeNotice(OfferNoticeType newNotice);
    }
}