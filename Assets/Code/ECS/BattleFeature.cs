using Code.ECS.Gameplay.Features.CharacterStats.Systems;
using Code.ECS.Gameplay.Features.Heroes;
using Code.ECS.Gameplay.Features.Input;
using Code.ECS.Gameplay.Features.Lifetime;
using Code.ECS.Gameplay.Features.Movement;
using Code.ECS.Gameplay.Features.Shoots;
using Code.ECS.Gameplay.Features.Shoots.Systems.Switching;
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
            Add(systems.Create<BindViewFeature>());
            Add(systems.Create<ViewActiveFeature>());
            Add(systems.Create<LifetimeFeature>());
            Add(systems.Create<ShootSwitchingFeature>());
            Add(systems.Create<ShootFeature>());
            Add(systems.Create<MovementFeature>());
            Add(systems.Create<HeroFeature>());
        }
    }
}