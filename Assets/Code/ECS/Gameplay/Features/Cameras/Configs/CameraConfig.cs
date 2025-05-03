namespace Code.ECS.Gameplay.Features.Cameras.Configs
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "CameraConfig", menuName = "CameraConfig", order = 1)]
    public class CameraConfig : ScriptableObject
    {
        public float CameraRotationSpeed = 1f;
        public float RotationSharpness = 10000f;
        public float MinCameraRotation = -90;
        public float MaxCameraRotation = 90;
    }
}