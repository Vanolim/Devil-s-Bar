using System;
using Core.Managers.ScreenManager;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationMenuView : IBaseScreen
    {
        void Initialize(Action back, Action menu, Action characters, Action skins, Action weapons);

        void SetCharacterInfo(string name, string description);
        UniTask ShowAfterChange();
        UniTask HideWithAnimation();
        UniTask HideViewWithTransitToChangeAnimation();
    }
}