using Code.ECS.Gameplay.Features.CharacterStats.Systems;
using Code.ECS.Gameplay.Features.Heroes;
using Code.ECS.Gameplay.Features.Input;
using Code.ECS.Gameplay.Features.Lifetime;
using Code.ECS.Gameplay.Features.Movement;
using Code.ECS.Gameplay.Features.Shoots;
using Code.ECS.Systems;
using Code.ECS.View;

namespace Code.ECS
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<ShootFeature>());
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<LifetimeFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<HeroFeature>());
            // Add(systems.Create<StatsFeature>());
            
            //
            // Add(systems.Create<ScaleFeature>());
            // Add(systems.Create<HeroFeature>());
            //
            // Add(systems.Create<CameraFeature>());
            // Add(systems.Create<EnemyFeature>());
            //
            //
            // Add(systems.Create<CooldownFeature>());
            // Add(systems.Create<EnchantFeature>());
            //
            // Add(systems.Create<LootingFeature>());
            //
            // Add(systems.Create<CollectTargetsFeature>());
            // Add(systems.Create<PullFeature>());
            // Add(systems.Create<LevelUpFeature>());
            // Add(systems.Create<AbilityFeature>());
            //
            // Add(systems.Create<StatusFeature>());
            // Add(systems.Create<EffectApplicationFeature>());
            // Add(systems.Create<StatusVisualsFeature>());
            // Add(systems.Create<ArmamentFeature>());
            // Add(systems.Create<EffectFeature>());
            // Add(systems.Create<StatsFeature>());
            // Add(systems.Create<FollowTargetFeature>());
            // Add(systems.Create<SkinFeature>());
            //
            // Add(systems.Create<MovementFeature>());
            // Add(systems.Create<ProcessDestructedFeature>());
            //
            // Add(systems.Create<DeathFeature>());
            // Add(systems.Create<GameOverOnHeroDeathSystem>());
            // Add(systems.Create<LifetimeFeature>());
        }
    }
}