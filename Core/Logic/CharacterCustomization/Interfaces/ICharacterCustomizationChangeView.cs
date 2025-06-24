using System;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationChangeView : IBaseScreen
    {
        void Initialize(Action back, Action home, Action randomCharacterInfo, Action<bool> randomCharacterChange);

        void SetCurrentCharacterInfo(string name, string description);
        
        void SetCharacters(ICharacterCustomizationSlotView[] characters);
        UniTask HideWithAnimation();
        UniTask HideViewWithTransitToMenuAnimation();
    }
}