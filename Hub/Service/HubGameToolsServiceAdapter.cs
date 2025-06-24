using Core.Services.GameToolsService.Interfaces;

namespace Hub.Service
{
    public class HubGameToolsServiceAdapter : IHubGameToolsServiceAdapter
    {
        private readonly IGameToolsDebugPresenter _gameToolsDebugPresenter;

        public HubGameToolsServiceAdapter(IGameToolsDebugPresenter gameToolsDebugPresenter)
        {
            _gameToolsDebugPresenter = gameToolsDebugPresenter;
        }

        public void SendDebugMessage(string message)
        {
            _gameToolsDebugPresenter.AddDebugMessage("[HUB] " + message);
        }
    }
}