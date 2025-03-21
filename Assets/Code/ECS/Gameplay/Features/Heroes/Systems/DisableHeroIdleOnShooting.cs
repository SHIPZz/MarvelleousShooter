using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroIdleOnShooting : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroIdleOnShooting(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
            
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable,
                    GameMatcher.Active,
                    GameMatcher.HeroGun));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity heroGun in _entities)
            {
                hero.isIdleAvailable = !heroGun.isShootingContinuously;
            }
        }
    }
}