using Code.ECS.Gameplay.Features.Cameras;
using Code.ECS.Gameplay.Features.CharacterStats.Systems;
using Code.ECS.Gameplay.Features.Collisions;
using Code.ECS.Gameplay.Features.Cooldown;
using Code.ECS.Gameplay.Features.Heroes;
using Code.ECS.Gameplay.Features.Input;
using Code.ECS.Gameplay.Features.Lifetime;
using Code.ECS.Gameplay.Features.Movement;
using Code.ECS.Gameplay.Features.Shoots;
using Code.ECS.Gameplay.Features.Shoots.Systems.Switching;
using Code.ECS.Gameplay.Features.TargetCollection;
using Code.ECS.Gameplay.Features.ViewActive;
using Code.ECS.Systems;
using Code.ECS.View;

namespace Code.ECS
{
    public sealed class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systems)
        {
            Add(systems.Create<InputFeature>());
            Add(systems.Create<CollectTargetsFeature>());
            Add(systems.Create<StatsFeature>());
            
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<CooldownFeature>());
            Add(systems.Create<ViewActiveFeature>());
            
            Add(systems.Create<LifetimeFeature>());
            Add(systems.Create<GunSwitchingFeature>());
            
            Add(systems.Create<GunFeature>());
            Add(systems.Create<CameraFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<HeroFeature>());
        }
    }
}