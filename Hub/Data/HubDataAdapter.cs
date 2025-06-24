using System.Collections.Generic;
using Core.Logic.Shop.Interfaces;
using Core.Services.SaveLoadService;
using Hub.Data.Interfaces;
using Zenject;

namespace Hub.Data
{
    public class HubDataAdapter : 
        IHubDataAdapter, 
        IShopDataAdapter,
        IInitializable
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IShop _shop;
        
        private HubData _currentHubData;

        public string CurrentCharacterId
        {
            get
            {
                ValidateData();
                return _currentHubData.CurrentCharacterId;
            }
        }

        public HubDataAdapter(ISaveLoadService saveLoadService, IShop shop)
        {
            _saveLoadService = saveLoadService;
            _shop = shop;
        }

        public void Initialize()
        {
            ValidateData();
            
            _shop.Initialize(this);
        }
        
        public void UpdateOpenCharacters()
        {
            _currentHubData = new HubData(
                _saveLoadService.CurrentData.SelectedCharacterId,
                GetOpenCharacters());
        }
        
        private void ValidateData()
        {
            if (_currentHubData.CurrentCharacterId == default)
            {
                _currentHubData = new HubData(
                    _saveLoadService.CurrentData.SelectedCharacterId,
                    GetOpenCharacters());
            }
        }
        
        private IReadOnlyDictionary<string, bool> GetOpenCharacters()
        {
            // Dictionary<string, bool> openCharacters = new Dictionary<string, bool>();
            //
            // string[] openCharactersId = _saveLoadService.CurrentData.OpenCharacters;
            // var allCharactersData = _charactersDataProvider.AllCharacters;
            //
            // foreach (var characterData in allCharactersData)
            // {
            //     bool isCharacterOpen = openCharactersId.Contains(characterData.Id);
            //     openCharacters.Add(characterData.Id, isCharacterOpen);
            // }
            //
            // return openCharacters;

            return null;
        }
    }
}