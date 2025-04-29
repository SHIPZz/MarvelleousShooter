using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class AllowHeroRunningAvailableSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public AllowHeroRunningAvailableSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.Hero);
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isRunningAvailable = true;
                hero.isRunningAnimAvailable = true;
            }
        }
    }
}