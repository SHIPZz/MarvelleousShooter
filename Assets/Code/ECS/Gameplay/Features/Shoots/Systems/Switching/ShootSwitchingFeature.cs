using Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching
{
    public sealed class ShootSwitchingFeature : Feature
    {
        public ShootSwitchingFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkShootSwitchingRequestedOnInputSystem>());
            Add(systems.Create<MarkShootSwitchingUnavailableOnSameGunSystem>());
            Add(systems.Create<SwitchShootSystem>());
            
            Add(systems.Create<HidePreviousGunOnSwitchingSystem>());
            Add(systems.Create<MarkPreviousGunNonActiveOnHidingSystem>());
            
            Add(systems.Create<ShowTargetGunOnSwitchingSystem>());
            Add(systems.Create<SetNewGunOnTargetGunShownSystem>());
            
            Add(systems.Create<MarkTargetGunActiveAfterSwitchingSystem>());
            Add(systems.Create<CleanupSwitchingSystem>());
        }
    }
}