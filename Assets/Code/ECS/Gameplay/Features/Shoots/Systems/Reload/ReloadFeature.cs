using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Reload.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public sealed class ReloadFeature : Feature
    {
        public ReloadFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkReloadRequestedOnInputSystem>());
            Add(systems.Create<MarkReloadRequestedOnNoAmmoSystem>());
            Add(systems.Create<DisableShootingSystem>());
            Add(systems.Create<PlayReloadAnimationSystem>());
            Add(systems.Create<CalculateReloadingTimeSystem>());
            Add(systems.Create<SetReloadFinishedOnReloadTimeSystem>());
            Add(systems.Create<CleanupReloadAfterTimeEndedSystem>());
        }
    }
}