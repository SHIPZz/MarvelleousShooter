using Code.ECS.Common.Services;
using Code.ECS.Gameplay.Features.Cameras.Configs;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras.Factories
{
    public class CameraFactory : ICameraFactory
    {
        private readonly IIdentifierService _identifierService;
        private readonly CameraConfig _cameraConfig;

        public CameraFactory(IIdentifierService identifierService, CameraConfig cameraConfig)
        {
            _cameraConfig = cameraConfig;
            _identifierService = identifierService;
        }

        public void CreateEntity(Camera camera)
        {
            Common.Entity.CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddMainCamera(camera)
                .AddCameraRotationSpeed(_cameraConfig.CameraRotationSpeed)
                .AddCameraRotationSharpness(_cameraConfig.RotationSharpness)
                .AddMinCameraRotation(_cameraConfig.MinCameraRotation)
                .AddMaxCameraRotation(_cameraConfig.MaxCameraRotation)
                .AddHorizontalRotation(0)
                .AddCurrentCameraRotation(camera.transform.rotation)
                .AddVerticalRotation(0)
                .AddTransform(camera.transform)
                ;

        }
    }
}