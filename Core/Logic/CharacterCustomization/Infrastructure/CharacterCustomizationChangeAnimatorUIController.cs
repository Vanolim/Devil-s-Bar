using Core.Logic.View.UIAnimatorController;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterCustomization.Infrastructure
{
    public class CharacterCustomizationChangeAnimatorUIController : AnimatorUIController
    {
        private const string _hideWithTransitToMenuState = "HideToMenu";
        
        [SerializeField]
        private int _hideWithTransitToMenuDelayMillisecondsTime;
        
        public UniTask PlayHideWithTransitToMenuAnimation()
        {
            Animator.SetTrigger(_hideWithTransitToMenuState);
            return UniTask.Delay(_hideWithTransitToMenuDelayMillisecondsTime);
        }
    }
}