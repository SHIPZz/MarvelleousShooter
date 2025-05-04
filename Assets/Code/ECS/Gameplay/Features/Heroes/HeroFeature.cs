using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Gameplay.Features.Heroes.Systems.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Heroes
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<AllowHeroAnimMovementSystem>());
            Add(systems.Create<AllowHeroRunningAvailableSystem>());
            
            Add(systems.Create<DisableHeroMovementAnimActiveOnGunActionSystem>());
            Add(systems.Create<DisableHeroRunningOnGunActionSystem>());
            
            Add(systems.Create<MarkHeroRunningSystem>());

            Add(systems.Create<PlayHeroAimAnimationSystem>());
            Add(systems.Create<PlayHeroAimShootAnimationSystem>());


            Add(systems.Create<SetupHeroGunOnSwitchingSystem>());


            Add(systems.Create<DisableShootingAvailableOnRunningSystem>());

            Add(systems.Create<ReplaceHeroSpeedOnInputSystem>());
        }
    }
}