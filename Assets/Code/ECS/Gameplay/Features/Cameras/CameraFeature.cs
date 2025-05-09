using Code.ECS.Gameplay.Features.Cameras.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Recoil;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Cameras
{
    public sealed class CameraFeature : Feature
    {
        public CameraFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetBaseCameraRotationOnInputSystem>());
            Add(systems.Create<ApplyCameraFinalRotationSystem>());
        }
    }
}