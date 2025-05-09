using Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching
{
    public sealed class GunSwitchingFeature : Feature
    {
        public GunSwitchingFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkSwitchingRequestedOnInputSystem>());
            Add(systems.Create<MarkSwitchingUnavailableOnSameGunSelectedSystem>());
            
            Add(systems.Create<SetTargetRequestedGunOnSwitchingSystem>());
            Add(systems.Create<ClearVisualProcessingOnQuickSwitchingSystem>());
            
            Add(systems.Create<MarkSwitchingStartedSystem>());
            Add(systems.Create<HideGunOnSwitchingStartedSystem>());
            
            Add(systems.Create<ShowGunOnHideSystem>());
            Add(systems.Create<SetNewGunToGunHolderSystem>());
            Add(systems.Create<MarkSwitchingFinishedOnShowingProcessedSystem>());
        }
    }
}