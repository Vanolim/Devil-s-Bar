using UnityEngine;

namespace Core.Infrastructure.ObjectProvider
{
    public interface ICoreObjectProvider
    {
        Transform GetCorePopupContainer(string screenKey);
        Transform GetObjectContainer();
    }
}