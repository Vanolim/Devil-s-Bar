using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Logic.View.UIAnimatorController
{
    public class AnimatorUIController : MonoBehaviour, IAnimatorUIController
    {
        private const string _hideState = "Hide";
        
        [SerializeField]
        private int _hideDelayMillisecondsTime;

        [SerializeField]
        private Animator _animator;

        protected Animator Animator => _animator;
        
        public UniTask PlayHideAnimation()
        {
            _animator.SetTrigger(_hideState);
            return UniTask.Delay(_hideDelayMillisecondsTime);
        }
    }
}