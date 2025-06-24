using Core.Infrastructure.ObjectContainer;
using Unity.Cinemachine;
using UnityEngine;

namespace Core.Infrastructure.ObjectProvider
{
    public class SceneObjectProvider : ISceneObjectProvider
    {
        private ISceneObjectContainer _sceneObjectContainer;
        
        public Transform GetScenePopupContainer(string screenKey)
        {
            return _sceneObjectContainer.GetViewParent(screenKey);
        }

        public Transform GetSceneObjectContainer()
        {
            return _sceneObjectContainer.SceneObjectParent;
        }
        
        public CinemachineCamera GetAnimationCamera()
        {
            return _sceneObjectContainer.GetCurrentCamera;
        }
        
        public void SetContainer(ISceneObjectContainer sceneObjectContainer)
        {
            _sceneObjectContainer = sceneObjectContainer;
        }
    }
}