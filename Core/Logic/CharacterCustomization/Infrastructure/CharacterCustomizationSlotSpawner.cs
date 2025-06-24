using Core.Infrastructure.Factories;
using Core.Infrastructure.ObjectProvider;
using Core.Logic.CharacterCustomization.Interfaces;
using Core.Services.ResourcesLoadService;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterCustomization.Infrastructure
{
    public class CharacterCustomizationSlotSpawner : ICharacterCustomizationSlotSpawner
    {
        private readonly IObjectFactory _objectFactory;
        private readonly ICoreObjectProvider _coreObjectProvider;

        public CharacterCustomizationSlotSpawner(IObjectFactory objectFactory, ICoreObjectProvider coreObjectProvider)
        {
            _objectFactory = objectFactory;
            _coreObjectProvider = coreObjectProvider;
        }
        
        public async UniTask<ICharacterCustomizationSlotView> GetUnlockSlot(string name, Sprite avatar, bool isSelect)
        {
            ICharacterCustomizationSlotView instance = await GetSlot();
            
            instance.SetUnlockData(name, avatar, isSelect);
            
            instance.Hide();

            return instance;
        }
        
        public async UniTask<ICharacterCustomizationSlotView> GetLockSlot(Sprite avatar, string price)
        {
            ICharacterCustomizationSlotView instance = await GetSlot();
            
            instance.SetLockData(avatar, price);
            
            instance.Hide();
            
            return instance;
        }

        private async UniTask<ICharacterCustomizationSlotView> GetSlot()
        {
            Transform parent = _coreObjectProvider.GetCorePopupContainer(null);
            
            return await _objectFactory
                .GetAsync<ICharacterCustomizationSlotView>(ResourcesProvider.UI.CharacterCustomizationSlotView, 
                    SceneLifeTimeHolder.SceneLifeTime, parent);
        }
    }
}