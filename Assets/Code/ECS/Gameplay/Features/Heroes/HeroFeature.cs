using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Gameplay.Features.Heroes.Systems.Visuals;
using Code.ECS.Gameplay.Features.Shoots.Systems.Aiming.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Heroes
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkHeroRunningSystem>());
            Add(systems.Create<MarkHeroOnGroundSystem>());
            Add(systems.Create<SetHeroRunningByOnGroundSystem>());
            Add(systems.Create<DisableHeroRunningAvailableOnShootSystem>());
            Add(systems.Create<SetHeroIdleAvailableOnShooting>());
            Add(systems.Create<PlayHeroAimAnimationSystem>());
            Add(systems.Create<PlayHeroAimShootAnimationSystem>());
            Add(systems.Create<DisableHeroMovementAnimOnShootSystem>());
            Add(systems.Create<DisableHeroMovementAnimationOnAimingSystem>());
            Add(systems.Create<SetShootingAvailableByHeroMovementSystem>());
            Add(systems.Create<SetHeroRunningAnimAvailableOnReloadSystem>());
            Add(systems.Create<SetHeroRunningAvailableOnAimingSystem>());
            Add(systems.Create<ReplaceHeroSpeedSystem>());
        }
    }
}