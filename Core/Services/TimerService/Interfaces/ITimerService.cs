using System;

namespace Core.Services.TimerService.Interfaces
{
    public interface ITimerService
    {
        bool IsPlaying { get; }
        void Start(float value, Action completed);
        void Stop();
    }
}