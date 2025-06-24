using Core.Infrastructure.Spawners.CharacterSpawner;
using Core.Services.ResourcesLoadService.LifeTime;
using Hub.Data;
using Hub.HubMenu;
using Hub.PlayerProfile;
using Hub.PlayerProfile.Data.PlayerAvatarData;
using Hub.PlayerProfile.PlayerChangeName;
using Hub.Service;
using UnityEngine;
using Zenject;

namespace Hub.Core
{
    public class HubInstaller : MonoInstaller
    {
        [SerializeField]
        private HubObjectContainer _hubObjectContainer;
        
        [SerializeField] 
        private PlayerAvatarsData _playerAvatarsData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<HubObjectContainer>().FromInstance(_hubObjectContainer).AsSingle();
            Container.BindInterfacesTo<HubDataAdapter>().AsSingle().NonLazy();
            Container.BindInterfacesTo<HubGameToolsServiceAdapter>().AsSingle();
            
            Container.BindInterfacesTo<CharacterSpawner>().AsSingle();

            Container.BindInterfacesTo<HubMenuPresenter>().AsSingle();

            BindPlayerProfile();
            
            Container.BindInterfacesTo<HubScreenManager.HubScreenManager>().AsSingle();
            Container.BindInterfacesTo<Hub>().AsSingle().NonLazy();
            
            SceneLifeTimeHolder.SetSceneLifeTime(new LifeTime());
        }

        private void BindPlayerProfile()
        {
            Container.Bind<PlayerAvatarsData>().FromInstance(_playerAvatarsData).AsSingle();
            
            Container.BindInterfacesTo<PlayerManualProfileService>().AsSingle();
            Container.BindInterfacesTo<ChangePlayerNameMessenger>().AsSingle();
            Container.BindInterfacesTo<ChangePlayerNamePresenter>().AsSingle();
            Container.BindInterfacesTo<PlayerManualProfilePresenter>().AsSingle();
        }
    }
}