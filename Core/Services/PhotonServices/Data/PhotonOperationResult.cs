using Core.Services.PhotonServices.Interfaces;

namespace Core.Services.PhotonServices.Data
{
    public class PhotonOperationResult : IPhotonOperationResult
    {
        public bool Success { get; }
        public short ErrorCode { get; }
        public string ErrorMessage { get; }

        public PhotonOperationResult(bool success)
        {
            Success = success;
            ErrorCode = default;
            ErrorMessage = null;
        }
        
        public PhotonOperationResult(bool success, short errorCode, string errorMessage)
        {
            Success = success;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        
        public PhotonOperationResult(bool success, string errorMessage)
        {
            Success = success;
            ErrorCode = default;
            ErrorMessage = errorMessage;
        }
    }
}