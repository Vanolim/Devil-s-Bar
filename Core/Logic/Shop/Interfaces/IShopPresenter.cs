using System;
using Cysharp.Threading.Tasks;

namespace Core.Logic.Shop.Interfaces
{
    public interface IShopPresenter
    {
        bool IsActive { get; }
        
        event Action OnBack;
        
        UniTask ShowView();
        void HideView();
    }
}