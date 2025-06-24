using Core.Infrastructure.ObjectContainer;
using UnityEngine;

namespace Core.Infrastructure.ObjectProvider
{
    public class CoreObjectProvider : ICoreObjectProvider
    {
        private readonly ICoreObjectContainer _coreObjectContainer;

        public CoreObjectProvider(ICoreObjectContainer coreObjectContainer)
        {
            _coreObjectContainer = coreObjectContainer;
        }

        public Transform GetCorePopupContainer(string screenKey)
        {
            return _coreObjectContainer.GetCoreViewParent(screenKey);
        }

        public Transform GetObjectContainer()
        {
            return _coreObjectContainer.CoreObjectParent;
        }
    }
}