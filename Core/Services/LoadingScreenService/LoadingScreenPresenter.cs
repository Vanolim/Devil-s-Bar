using Core.Managers.ScreenManager;
using Core.Services.LoadingScreenService.Interfaces;
using Core.Services.ResourcesLoadService;
using Cysharp.Threading.Tasks;

namespace Core.Services.LoadingScreenService
{
    public class LoadingScreenPresenter : ILoadingScreenPresenter
    {
        private readonly ICoreScreenManager _coreScreenManager;

        private ILoadingScreenView _view;

        public LoadingScreenPresenter(ICoreScreenManager coreScreenManager)
        {
            _coreScreenManager = coreScreenManager;
        }

        public async UniTask ShowView()
        {
            _view = await _coreScreenManager.ShowCoreAsync<ILoadingScreenView>(ResourcesProvider.UI.LoadingScreenView);
        }

        public void HideView()
        {
            if (_view != null)
            {
                _view.Hide();
            }
        }
    }
}