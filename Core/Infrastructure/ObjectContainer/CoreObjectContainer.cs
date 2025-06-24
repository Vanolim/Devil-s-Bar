using System.Linq;
using UnityEngine;

namespace Core.Infrastructure.ObjectContainer
{
    public class CoreObjectContainer : MonoBehaviour, ICoreObjectContainer
    {
        [SerializeField]
        private ScreenSpecialParentModel[] _specialPopusContainer;
        
        [SerializeField] 
        private RectTransform _coreViewParent;
        
        [SerializeField] 
        private Transform _coreObjectParent;
        
        public RectTransform CoreViewParent => _coreViewParent;
        
        public Transform CoreObjectParent => _coreObjectParent;
        
        public RectTransform GetCoreViewParent(string screenKey)
        {
            if (_specialPopusContainer == null || screenKey == null)
            {
                return _coreViewParent;
            }
            
            var specialPopupContainer = _specialPopusContainer.FirstOrDefault(x => x.ScreenId == screenKey);
            
            if (specialPopupContainer.Parent != null)
            {
                return specialPopupContainer.Parent;
            }
            
            return _coreViewParent;
        }
    }
}