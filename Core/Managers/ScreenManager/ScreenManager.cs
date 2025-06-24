using System.Collections.Generic;
using System.Linq;
using Core.Infrastructure.Factories;
using Core.Infrastructure.ObjectProvider;
using Core.Services.ResourcesLoadService.LifeTime;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Core.Managers.ScreenManager
{
    public class ScreenManager : BaseManager, IScreenManager, ISceneScreenManager, ICoreScreenManager
    {
        private readonly Dictionary<string, IBaseScreen> _activeScreens = new();

        public ScreenManager(IObjectFactory objectFactory, ICoreObjectProvider coreObjectProvider, ISceneObjectProvider sceneObjectProvider) : base(objectFactory, coreObjectProvider, sceneObjectProvider)
        {
        }

        public async UniTask<T> ShowAsync<T>(string screenKey, bool show = true) where T : IBaseScreen
        {
            ILifeTime lifeTime = SceneLifeTimeHolder.SceneLifeTime;
            Transform parent = SceneObjectProvider.GetScenePopupContainer(screenKey);
            
            return await GetObjectAsync<T>(screenKey, lifeTime, parent, show);
        }

        public async UniTask<T> ShowCoreAsync<T>(string screenKey, bool show = true) where T : IBaseScreen
        {
            ILifeTime lifeTime = SceneLifeTimeHolder.ProjectLifeTime;
            Transform parent = CoreObjectProvider.GetCorePopupContainer(screenKey);
            
            return await GetObjectAsync<T>(screenKey, lifeTime, parent, show);
        }
        
        private async UniTask<T> GetObjectAsync<T>(string screenKey, ILifeTime lifeTime, Transform parent, bool show = true) where T : IBaseScreen
        {
            var instance = await GetAsync<T>(screenKey, lifeTime, parent);
            
            if (_activeScreens.ContainsKey(screenKey) == false)
            {
                _activeScreens.Add(screenKey, instance);
            }

            instance.OnDestroyed += RemoveDestroyedScreen;
            
            if (show)
            {
                instance.Show();
            }
            
            return instance;
        }

        protected override bool IsAlreadyHasTargetObject<T>(string targetScreenKey, out T targetScreen)
        {
            if (_activeScreens.ContainsKey(targetScreenKey))
            {
                targetScreen = (T)_activeScreens[targetScreenKey];
                return true;
            }

            targetScreen = default;
            return false;
        }

        private void RemoveDestroyedScreen(IBaseScreen baseScreen)
        {
            foreach (var activeScreen in _activeScreens.ToList())
            {
                if (activeScreen.Value == baseScreen)
                {
                    activeScreen.Value.OnDestroyed -= RemoveDestroyedScreen;
                    _activeScreens.Remove(activeScreen.Key);
                }
            }
        }
    }
}