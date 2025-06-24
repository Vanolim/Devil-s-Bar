using System;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShop
    {
        void Activate();
        void Deactivate();
        
        void Initialize(IShopDataAdapter shopDataAdapter);
        public void TryPurchaseCharacter(string characterId, Action onCharacterPurchased);
    }
}