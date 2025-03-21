using Code.ECS.Gameplay.Features.Heroes.Systems;
using Code.ECS.Gameplay.Features.Heroes.Systems.Visuals;
using Code.ECS.Gameplay.Features.Shoots.Systems.Aiming.Visuals;
using Code.ECS.Systems;
using Code.Gameplay.Heroes.Services;
using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes
{
    public sealed class HeroFeature : Feature
    {
        public HeroFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkHeroRunningSystem>());
            Add(systems.Create<MarkHeroOnGroundSystem>());

            Add(systems.Create<DisableHeroIdleOnShooting>());

            Add(systems.Create<PlayHeroAimAnimationSystem>());
            Add(systems.Create<PlayHeroAimShootAnimationSystem>());

            Add(systems.Create<DisableHeroMovementAnimOnGunActionSystem>());

            Add(systems.Create<SetupHeroGunOnSwitchingSystem>());

            Add(systems.Create<DisableHeroRunningOnGunActionSystem>());
            Add(systems.Create<DisableHeroRunningAnimOnGunActionSystem>());

            Add(systems.Create<MarkShootingAvailableOnNoRunningSystem>());

            Add(systems.Create<ReplaceHeroSpeedOnInputSystem>());
        }
    }
}