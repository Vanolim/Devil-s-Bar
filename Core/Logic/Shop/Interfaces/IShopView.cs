using System;
using System.Collections.Generic;
using Core.Managers.ScreenManager;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopView : IBaseScreen
    {
        IReadOnlyCollection<IShopCoinOfferView> CoinOffers { get; }
        
        void Initialize(Action back, Action<string> coinOfferSelected);
    }
}