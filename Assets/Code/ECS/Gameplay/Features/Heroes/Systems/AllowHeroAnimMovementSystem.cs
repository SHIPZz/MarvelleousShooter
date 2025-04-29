using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class AllowHeroAnimMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public AllowHeroAnimMovementSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
                hero.isMovementAnimAvailable = true;
        }
    }
}