using UnityEngine;

namespace Core.Infrastructure.ObjectContainer
{
    public interface ICoreObjectContainer
    {
        Transform CoreObjectParent { get; }

        RectTransform GetCoreViewParent(string screenKey);
    }
}