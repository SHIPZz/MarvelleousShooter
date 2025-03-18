using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class DisableHeroMovementAnimOnGunSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switching;
        private readonly IGroup<GameEntity> _heroes;

        public DisableHeroMovementAnimOnGunSwitchingSystem(GameContext game)
        {
            _switching = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switching));

            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.Id));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isMovementAnimAvailable = _switching.GetEntities().Length <= 0;
            }
        }
    }
}