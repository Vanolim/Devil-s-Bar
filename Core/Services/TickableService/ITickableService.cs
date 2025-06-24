namespace Core.Services.TickableService
{
    public interface ITickableService
    {
        void Add(ITickable value);
        void Remove(ITickable value);
    }
}