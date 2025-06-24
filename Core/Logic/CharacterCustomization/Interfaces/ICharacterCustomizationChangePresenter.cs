using System;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationChangePresenter
    { 
        event Action OnBack;
        event Action OnHome;
        
        UniTask ShowView();
        void HideView();
        UniTask HideViewWithTransitToMenuAnimation();
        UniTask HideViewWithAnimation();
    }
}