using Cysharp.Threading.Tasks;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopOffersDataAdapter
    {
        UniTask<IShopCoinOfferModel> GetCoinOfferData(string coinOfferId);
    }
}