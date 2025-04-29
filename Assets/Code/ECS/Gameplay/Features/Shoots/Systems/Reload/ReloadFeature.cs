using Code.ECS.Gameplay.Features.Shoots.Systems.Reload.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public sealed class ReloadFeature : Feature
    {
        public ReloadFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkReloadingOnInputSystem>());
            Add(systems.Create<MarkReloadRequestedOnNoAmmoSystem>());
            
            Add(systems.Create<PlayReloadAnimationSystem>());
            
            Add(systems.Create<CancelReloadOnGunSwitchingSystem>());
            
            Add(systems.Create<CalculateReloadingTimeSystem>());
           
            Add(systems.Create<PutOnAmmoOnReloadTimeUpSystem>());
            
            Add(systems.Create<CleanupReloadAfterTimeEndedSystem>());
        }
    }
}