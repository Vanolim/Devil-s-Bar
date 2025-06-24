using Unity.Cinemachine;
using UnityEngine;

namespace Core.Infrastructure.ObjectContainer
{
    public interface ISceneObjectContainer
    {
        Transform SceneObjectParent { get; }
        CinemachineCamera GetCurrentCamera { get; }
        RectTransform GetViewParent(string screenKey);
    }
}