using System.Linq;
using Core.Infrastructure.ObjectContainer;
using Core.Infrastructure.ObjectProvider;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Hub.Core
{
    public class HubObjectContainer : MonoBehaviour, ISceneObjectContainer
    {
        [SerializeField]
        private ScreenSpecialParentModel[] _specialPopusContainer;
            
        [SerializeField]
        private RectTransform _popupContainer;

        [SerializeField]
        private Transform _sceneObjectContainer;
        
        [SerializeField]
        private CinemachineCamera _currentCamera;
        
        public Transform SceneObjectParent => _sceneObjectContainer;
        public CinemachineCamera GetCurrentCamera => _currentCamera;

        [Inject]
        private void Construct(ISceneObjectProvider sceneObjectProvider)
        {
            sceneObjectProvider.SetContainer(this);
        }
        
        public RectTransform GetViewParent(string screenKey)
        {
            if (_specialPopusContainer == null)
            {
                return _popupContainer;
            }
            
            var specialPopupContainer = _specialPopusContainer.FirstOrDefault(x => x.ScreenId == screenKey);
            
            if (specialPopupContainer.Parent != null)
            {
                return specialPopupContainer.Parent;
            }
            
            return _popupContainer;
        }
    }
}