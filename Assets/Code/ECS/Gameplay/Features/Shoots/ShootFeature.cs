using Code.ECS.Gameplay.Features.Shoots.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Aiming;
using Code.ECS.Gameplay.Features.Shoots.Systems.Ammo;
using Code.ECS.Gameplay.Features.Shoots.Systems.Recoil;
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
            Add(systemFactory.Create<MarkShootAnimStoppedOnEnd>());
            Add(systemFactory.Create<ShootWithoutAmmoOnReadySystem>());
            
            Add(systemFactory.Create<MarkShootingContinuouslySystem>());
            Add(systemFactory.Create<CastRaycastOnShootingSystem>());
            Add(systemFactory.Create<AlignEffectOnHitSystem>());

            Add(systemFactory.Create<PlayCameraShakeOnShootSystem>());
            
            Add(systemFactory.Create<RecoilFeature>());
            
            Add(systemFactory.Create<ReloadFeature>());
            Add(systemFactory.Create<AimingFeature>());
            
            Add(systemFactory.Create<PlayAnimationOnShootSystem>());
            Add(systemFactory.Create<PlayEffectOnShootSystem>());
            
            Add(systemFactory.Create<SetLastShootTimeOnShootingSystem>());
            Add(systemFactory.Create<CalculateAmmoCountOnShootSystem>());
            Add(systemFactory.Create<MarkAmmoAvailableSystem>());
            
            
            Add(systemFactory.Create<CleanupShootRaycastHitsSystem>());
            
            Add(systemFactory.Create<CleanupGunOnNonActiveSystem>());
            
            Add(systemFactory.Create<CleanupShootingSystem>());
        }
    }
}