using Core.Services.ResourcesLoadService;
using Core.Services.SceneLoader.Interfaces;
using Hub.HubScreenManager;
using Zenject;

namespace Hub.Core
{
    public class Hub : IInitializable
    {
        private readonly IHubScreenManager _hubScreenManager;
        private readonly ISceneLoader _sceneLoader;

        public Hub(IHubScreenManager hubScreenManager, ISceneLoader sceneLoader)
        {
            _hubScreenManager = hubScreenManager;
            _sceneLoader = sceneLoader;
        }

        public void Initialize()
        {
            _hubScreenManager.OnPlay += LoadLobby;
            _hubScreenManager.Activate();
        }

        private void LoadLobby()
        {
            _hubScreenManager.OnPlay -= LoadLobby;
            
            _sceneLoader.LoadAsync(ResourcesProvider.Scene.Lobby);
            
            _hubScreenManager.Deactivate();
        }
    }
}