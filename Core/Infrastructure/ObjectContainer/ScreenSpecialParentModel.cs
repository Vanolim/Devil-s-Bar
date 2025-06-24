using System;
using UnityEngine;

namespace Core.Infrastructure.ObjectContainer
{
    [Serializable]
    public struct ScreenSpecialParentModel
    {
        public string ScreenId;
        public RectTransform Parent;
    }
}