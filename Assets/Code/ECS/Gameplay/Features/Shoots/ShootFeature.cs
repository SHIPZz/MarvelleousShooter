using Code.ECS.Gameplay.Features.Movement.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.Aiming;
using Code.ECS.Gameplay.Features.Shoots.Systems.Ammo;
using Code.ECS.Gameplay.Features.Shoots.Systems.Cooldowns;
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
            Add(systemFactory.Create<AllowShootAvailableSystem>());
            Add(systemFactory.Create<DisableShootingOnReloadSystem>());
            
            Add(systemFactory.Create<MarkShootingRequestedOnInputSystem>());
            
            Add(systemFactory.Create<CalculateShootCooldownSystem>());
            
            Add(systemFactory.Create<ShootOnCooldownUpSystem>());
            
            Add(systemFactory.Create<DecreaseSpeedOnShootSystem>());
            
            Add(systemFactory.Create<MarkShootCooldownProcessingOnShootSystem>());
            
            Add(systemFactory.Create<ShootWithoutAmmoOnCooldownUpSystem>());
            
            Add(systemFactory.Create<MarkShootingAnimationProcessingSystem>());
            
            Add(systemFactory.Create<ResetShootCooldownSystem>());
            
            Add(systemFactory.Create<MarkShootingContinuouslySystem>());
            Add(systemFactory.Create<CastRaycastByCameraOnShootingSystem>());
            Add(systemFactory.Create<AlignEffectOnHitSystem>());

            Add(systemFactory.Create<PlayAnimationOnShootSystem>());
            
            Add(systemFactory.Create<PlayMoveGunAnimOnShootSystem>());
            
            Add(systemFactory.Create<PlayEffectOnShootSystem>());

            Add(systemFactory.Create<PlayCameraShakeOnShootSystem>());
            
            Add(systemFactory.Create<RecoilFeature>());
            
            Add(systemFactory.Create<ReloadFeature>());
            Add(systemFactory.Create<AimingFeature>());
            
            Add(systemFactory.Create<SetLastShootTimeOnShootingSystem>());
            Add(systemFactory.Create<CalculateAmmoCountOnShootSystem>());
            Add(systemFactory.Create<MarkAmmoAvailableSystem>());
            
            Add(systemFactory.Create<CleanupShootRaycastHitsSystem>());
         
            Add(systemFactory.Create<CleanupShootingSystem>());
            
            Add(systemFactory.Create<CleanupShootingStartedSystem>());
            
            Add(systemFactory.Create<CleanupGunOnNonActiveSystem>());
        }
    }
}