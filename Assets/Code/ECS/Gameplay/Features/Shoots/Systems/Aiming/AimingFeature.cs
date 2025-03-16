using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Aiming
{
    public sealed class AimingFeature : Feature
    {
        public AimingFeature(ISystemFactory systems)
        {
            Add(systems.Create<DisableAimingOnReloadSystem>());
            Add(systems.Create<MarkAimingRequestedOnInputSystem>());
            Add(systems.Create<MarkAimOnAimingRequested>());
        }
    }
}