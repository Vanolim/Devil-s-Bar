using System;
using Core.Managers.ScreenManager;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopCoinOfferView : IBaseScreen
    {
        string CoinOfferId { get; }

        void Initialize(string price, string coinValue, Action<string> select);

        void ShowNotice(string noticeMessage);
        void HideNotice();
    }
}