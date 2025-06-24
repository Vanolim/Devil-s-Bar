using System;

namespace Core.Managers.GameObjectManager
{
    public interface IBaseGameObject
    {
        event Action<IBaseGameObject> OnDestroyed;
    }
}