using UnityEngine;

namespace Core.Managers.CameraController.Data
{
    [CreateAssetMenu(fileName = "CameraAnimationData", menuName = "ScriptableObjects/CameraAnimationData")]
    public class CameraAnimationData : ScriptableObject
    {
        public CharacterCustomizationCameraAnimationData CharacterCustomizationCameraAnimationData;
    }
}