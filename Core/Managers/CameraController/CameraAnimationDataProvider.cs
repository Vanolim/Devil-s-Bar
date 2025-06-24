using Core.Managers.CameraController.Data;
using Core.Managers.CameraController.Interfaces;

namespace Core.Managers.CameraController
{
    public class CameraAnimationDataProvider : ICameraAnimationDataProvider
    {
        private readonly CameraAnimationData _cameraAnimationData;

        public CameraAnimationDataProvider(CameraAnimationData cameraAnimationData)
        {
            _cameraAnimationData = cameraAnimationData;
        }

        public CharacterCustomizationCameraAnimationData GetCharacterCustomizationCameraAnimationData()
        {
            return _cameraAnimationData.CharacterCustomizationCameraAnimationData;
        }
    }
}