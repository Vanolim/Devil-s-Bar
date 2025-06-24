using Core.Services.LoadingScreenService;
using Core.Services.LoadingScreenService.Interfaces;
using Core.Services.SceneLoader.Interfaces;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Core.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ILoadingScreenPresenter _loadingScreenPresenter;

        public SceneLoader(ILoadingScreenPresenter loadingScreenPresenter)
        {
            _loadingScreenPresenter = loadingScreenPresenter;
        }

        public async UniTask LoadAsync(string sceneKey)
        {
            await _loadingScreenPresenter.ShowView();
            await Addressables.LoadSceneAsync(sceneKey);
        }
    }
}