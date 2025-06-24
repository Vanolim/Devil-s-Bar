using System;
using Core.Logic.Shop.Interfaces;
using Core.Services.SaveLoadService;

namespace Core.Logic.Shop
{
    public class Shop : IShop
    {
        private readonly ISaveLoadService _saveLoadService;
        
        private IShopDataAdapter _shopDataAdapter;

        public Shop(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            throw new NotImplementedException();
        }

        public void Initialize(IShopDataAdapter shopDataAdapter)
        {
            _shopDataAdapter = shopDataAdapter;
        }

        public void TryPurchaseCharacter(string characterId, Action onCharacterPurchased)
        {
            SavePurchaseCharacter(characterId);
            _shopDataAdapter.UpdateOpenCharacters();
            
            onCharacterPurchased?.Invoke();
        }

        private void SavePurchaseCharacter(string characterId)
        {
            var currentData = _saveLoadService.CurrentData;
            
            var openCharacters = currentData.OpenCharacters;
            Array.Resize(ref openCharacters, openCharacters.Length + 1);
            openCharacters[^1] = characterId;
            currentData.OpenCharacters = openCharacters;
            
            _saveLoadService.SaveData(currentData);
        }
    }
}