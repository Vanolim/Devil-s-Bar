using Core.Data.CharacterData;
using Core.Data.GameplaySettingsData;
using Core.Data.PlayerData;
using Core.Infrastructure.ObjectContainer;
using Core.Infrastructure.ObjectProvider;
using Core.Infrastructure.Spawners.CharacterSpawner;
using Core.Logic.CharacterCustomization;
using Core.Logic.CharacterCustomization.Infrastructure;
using Core.Logic.CharacterModelDisplayer;
using Core.Logic.Shop;
using Core.Logic.Shop.Data;
using Core.Logic.Wallet;
using Core.Managers.CameraController;
using Core.Managers.CameraController.Data;
using Core.Managers.GameObjectManager;
using Core.Managers.ScreenManager;
using Core.Services.GameToolsService;
using Core.Services.GameToolsService.GameDebugView;
using Core.Services.GameToolsService.GameInfoView;
using Core.Services.LoadingScreenService;
using Core.Services.PhotonServices;
using Core.Services.PhotonServices.PhotonCustomProperty;
using Core.Services.PhotonServices.PhotonEventHandler;
using Core.Services.ResourcesLoadService;
using Core.Services.ResourcesLoadService.LifeTime;
using Core.Services.SaveLoadService;
using Core.Services.SceneLoader;
using Core.Services.TickableService;
using Core.Services.TimerService;
using UnityEngine;
using Zenject;
using ObjectFactory = Core.Infrastructure.Factories.ObjectFactory;

namespace Core
{
    public class CoreInstaller : MonoInstaller
    {
        [SerializeField] 
        private GameplaySettingsData _gameplaySettingsData;
        
        [SerializeField]
        private CharactersData _charactersData;

        [SerializeField]
        private CameraAnimationData _cameraAnimationData;
        
        [SerializeField] 
        private CoreObjectContainer _coreObjectContainer;
        
        [SerializeField]
        private CoinOffersData _coinOffersData;
        
        public override void InstallBindings()
        {
            BindData();
            BindInfrastructure();
            BindManagers();
            BindServices();
            BindLogic();

            SceneLifeTimeHolder.ProjectLifeTime = new LifeTime();
        }

        private void BindData()
        {
            CharactersDataProvider charactersDataProvider = new CharactersDataProvider(_charactersData);
            Container.BindInterfacesTo<CharactersDataProvider>().FromInstance(charactersDataProvider).AsSingle();

            GameplaySettingsDataAdapter gameplaySettingsDataAdapter = new GameplaySettingsDataAdapter(_gameplaySettingsData);
            Container.BindInterfacesTo<GameplaySettingsDataAdapter>().FromInstance(gameplaySettingsDataAdapter).AsSingle();
            
            Container.BindInterfacesTo<PlayerDataAdapter>().AsSingle();
        }

        private void BindInfrastructure()
        {
            Container.BindInterfacesTo<ObjectFactory>().AsSingle();
            Container.BindInterfacesTo<CoreObjectContainer>().FromInstance(_coreObjectContainer).AsSingle();
            Container.BindInterfacesTo<CoreObjectProvider>().AsSingle();
            Container.BindInterfacesTo<SceneObjectProvider>().AsSingle();
            
            Container.BindInterfacesTo<CharacterPhotonRegister>().AsSingle();
            Container.BindInterfacesTo<CharacterSpawner>().AsSingle();
        }

        private void BindManagers()
        {
            Container.BindInterfacesTo<ScreenManager>().AsSingle();
            Container.BindInterfacesTo<GameObjectManager>().AsSingle();

            CameraAnimationDataProvider cameraAnimationDataProvider = new CameraAnimationDataProvider(_cameraAnimationData);
            Container.BindInterfacesTo<CameraAnimationDataProvider>().FromInstance(cameraAnimationDataProvider);
            Container.BindInterfacesTo<CameraController>().AsSingle();
        }

        private void BindServices()
        {
            BindGameToolsService();
            
            Container.BindInterfacesTo<ResourcesLoadService>().AsSingle();
            Container.BindInterfacesTo<LoadingScreenPresenter>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<TickableService>().AsSingle();
            Container.BindInterfacesTo<SaveLoadService>().AsSingle();
            Container.BindInterfacesTo<TimerService>().AsSingle();
            
            //Photon services
            Container.BindInterfacesTo<PhotonCustomPropertyAdapter>().AsSingle();
            Container.BindInterfacesTo<PhotonService>().AsSingle();
            Container.BindInterfacesTo<PhotonEventHandler>().AsSingle();
        }
        
        private void BindLogic()
        {
            Container.BindInterfacesTo<Wallet>().AsSingle();
            Container.BindInterfacesTo<WalletPresenter>().AsSingle();
            
            CoinOffersDataAdapter coinOffersDataAdapter = new CoinOffersDataAdapter(_coinOffersData);
            Container.BindInterfacesTo<CoinOffersDataAdapter>().FromInstance(coinOffersDataAdapter);
            Container.BindInterfacesTo<ShopOffersDataAdapter>().AsSingle();
            Container.BindInterfacesTo<ShopService>().AsSingle();
            Container.BindInterfacesTo<ShopPresenter>().AsSingle();
            Container.BindInterfacesTo<ShopScreenManager>().AsSingle().NonLazy();
            Container.BindInterfacesTo<Shop>().AsSingle();

            Container.BindInterfacesTo<CharacterModelBackgroundProvider>().AsSingle();
            Container.BindInterfacesTo<CharacterModelService>().AsSingle();
            Container.BindInterfacesTo<CharacterModelPresenter>().AsSingle();

            Container.BindInterfacesTo<CharacterCustomizationDataAdapter>().AsSingle();
            Container.BindInterfacesTo<CharacterCustomizationSlotSpawner>().AsSingle();
            Container.BindInterfacesTo<CharacterCastomizationService>().AsSingle();
            Container.BindInterfacesTo<CharacterCustomizationChangePresenter>().AsSingle();
            Container.BindInterfacesTo<CharacterCustomizationMenuPresenter>().AsSingle();
            Container.BindInterfacesTo<CharacterCustomizationPresenter>().AsSingle();
        }

        private void BindGameToolsService()
        {
            Container.BindInterfacesTo<GameToolsPresenter>().AsSingle();
            Container.BindInterfacesTo<GameToolsMenuPresenter>().AsSingle();
            Container.BindInterfacesTo<GameToolsInfoPresenter>().AsSingle();
            Container.BindInterfacesTo<GameToolsDebugPresenter>().AsSingle();
            Container.BindInterfacesTo<GameToolsScreenManager>().AsSingle().NonLazy();
        }
    }
}