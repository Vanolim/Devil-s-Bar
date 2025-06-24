using System;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationMenuPresenter
    {
        event Action OnBack;
        event Action OnMenu;
        event Action OnCharacters;
        event Action OnSkins;
        event Action OnWeapons;

        UniTask ShowView();
        UniTask ShowViewWithAnimationAfterChange();
        void HideView();
        UniTask HideViewWithTransitToChangeAnimation();
        UniTask HideViewWithAnimation();
    }
}