namespace Core.Services.ResourcesLoadService.LifeTime
{
    public static class SceneLifeTimeHolder
    {
        public static ILifeTime ProjectLifeTime { get; set; }
        public static ILifeTime SceneLifeTime { get; set; }

        public static void SetSceneLifeTime(ILifeTime lifetime)
        {
            SceneLifeTime?.Dispose();
            
            SceneLifeTime = lifetime;
        }
    }
}