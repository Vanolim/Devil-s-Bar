using Core.Services.ResourcesLoadService.LifeTime;

namespace Core.Services.TickableService
{
    public interface IManualTickableService
    {
        void Start(ILifeTime lifeTime);
        void Pause();
        void UnPause();
        void Stop();
    }
}