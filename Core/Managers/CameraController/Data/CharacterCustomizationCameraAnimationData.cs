using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Managers.CameraController.Data
{
    [Serializable]
    public struct CharacterCustomizationCameraAnimationData
    {
        public Vector3 TargetMove;
        public float CameraAnimationDuration;
        public Ease MovementEase; 
    }
}