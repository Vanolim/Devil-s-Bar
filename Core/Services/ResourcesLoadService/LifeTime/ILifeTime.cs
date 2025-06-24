using System.Threading;
using Cysharp.Threading.Tasks;

namespace Core.Services.ResourcesLoadService.LifeTime
{
    public interface ILifeTime
    {
        bool IsOngoing { get; }
        CancellationToken CancellationToken { get; }
        UniTask WaitForEnd();
        void Dispose();
    }
}