using Core.Logic.View.UIAnimatorController;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.CharacterCustomization.Infrastructure
{
    public class CharacterCustomizationMenuAnimatorUIController : AnimatorUIController
    {
        private const string _hideWithTransitToMenuState = "HideToChange";
        private const string _showAfterChange = "ShowAfterChange";
        
        [SerializeField]
        private int _hideWithTransitToChangeDelayMillisecondsTime;
        
        [SerializeField]
        private int _showAfterChangeDelayMillisecondTime;
        
        public UniTask PlayHideWithTransitToChangeAnimation()
        {
            Animator.SetTrigger(_hideWithTransitToMenuState);
            return UniTask.Delay(_hideWithTransitToChangeDelayMillisecondsTime);
        }

        public UniTask PlayShowAfterChangeAnimation()
        {
            Animator.SetTrigger(_showAfterChange);
            return UniTask.Delay(_showAfterChangeDelayMillisecondTime);
        }
    }
}