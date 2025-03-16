using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Heroes
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkHeroRunningSystem>());
            Add(systems.Create<MarkHeroRunningAvailableOnShootSystem>());
            Add(systems.Create<MarkHeroOnGroundSystem>());
            Add(systems.Create<SetHeroRunningByOnGroundSystem>());
            Add(systems.Create<SetHeroIdleAvailableOnShooting>());
            Add(systems.Create<DisableHeroMovementAnimOnShootSystem>());
            Add(systems.Create<SetShootingAvailableByHeroMovementSystem>());
            Add(systems.Create<ReplaceHeroSpeedSystem>());
        }
    }
}