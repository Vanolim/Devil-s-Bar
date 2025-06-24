using Core.Infrastructure.ObjectContainer;
using Unity.Cinemachine;
using UnityEngine;

namespace Core.Infrastructure.ObjectProvider
{
    public interface ISceneObjectProvider
    {
        Transform GetScenePopupContainer(string screenKey);
        Transform GetSceneObjectContainer();
        void SetContainer(ISceneObjectContainer sceneObjectContainer);
        CinemachineCamera GetAnimationCamera();
    }
}