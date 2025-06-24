using System;
using Cysharp.Threading.Tasks;

namespace Core.Logic.CharacterCustomization.Interfaces
{
    public interface ICharacterCustomizationPresenter
    {
        event Action OnHome;
        
        void ShowView();
        void HideView();
        UniTask HideViewWithAnimation();
    }
}