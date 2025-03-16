using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Aiming;
using Code.ECS.Gameplay.Features.Shoots.Systems.Reload;
using Code.ECS.Gameplay.Features.Shoots.Systems.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots
{
    public class ShootFeature : Feature
    {
        public ShootFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkShootingRequestedOnInputSystem>());
            Add(systemFactory.Create<MarkShootingReadySystem>());
            Add(systemFactory.Create<ShootOnReadySystem>());
            Add(systemFactory.Create<MarkShootingContinuouslySystem>());
            Add(systemFactory.Create<CastRaycastOnShootingSystem>());
            Add(systemFactory.Create<AlignEffectOnRaycastHitSystem>());

            Add(systemFactory.Create<ReloadFeature>());
            Add(systemFactory.Create<AimingFeature>());
            
            Add(systemFactory.Create<PlayAnimationOnShootSystem>());
            Add(systemFactory.Create<PlayEffectOnShootSystem>());
            Add(systemFactory.Create<SetAnimationFinishedSystem>());
            
            Add(systemFactory.Create<SetLastShootTimeOnShootingSystem>());
            Add(systemFactory.Create<CalculateAmmoCountOnShootSystem>());
            Add(systemFactory.Create<MarkAmmoAvailableSystem>());
            
            Add(systemFactory.Create<StopShootingOnNoInputSystem>());
            
            Add(systemFactory.Create<CleanupShootRaycastHitsSystem>());
            Add(systemFactory.Create<CleanupShootingSystem>());
        }
    }
}