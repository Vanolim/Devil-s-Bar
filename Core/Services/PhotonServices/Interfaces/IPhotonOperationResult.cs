namespace Core.Services.PhotonServices.Interfaces
{
    public interface IPhotonOperationResult
    {
        bool Success { get; }
        short ErrorCode { get; }
        string ErrorMessage { get; }
    }
}