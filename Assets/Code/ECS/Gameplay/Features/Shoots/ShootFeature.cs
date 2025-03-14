using Code.ECS.Gameplay.Features.Shoots.Systems;
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
            Add(systemFactory.Create<PlayAnimationOnShootSystem>());
            Add(systemFactory.Create<PlayEffectOnShootSystem>());
            Add(systemFactory.Create<SetAnimationFinishedSystem>());
            
            Add(systemFactory.Create<SetLastShootTimeOnShooting>());
            Add(systemFactory.Create<CalculateAmmoCountOnShoot>());
            Add(systemFactory.Create<MarkAmmoAvailableSystem>());
            
            Add(systemFactory.Create<CleanupShootingSystem>());
        }
    }
}