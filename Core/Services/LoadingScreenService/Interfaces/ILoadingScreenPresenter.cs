using Cysharp.Threading.Tasks;

namespace Core.Services.LoadingScreenService.Interfaces
{
    public interface ILoadingScreenPresenter
    {
        UniTask ShowView();
        void HideView();
    }
}