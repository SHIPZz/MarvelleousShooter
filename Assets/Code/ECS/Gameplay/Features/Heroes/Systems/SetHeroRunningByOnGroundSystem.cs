using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class SetHeroRunningByOnGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public SetHeroRunningByOnGroundSystem(GameContext game)
        {
            _heroes = game.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.CanRun));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isRunningAvailable = hero.isOnGround;
                
                if(!hero.isOnGround)
                    hero.isRunning = false;
            }
        }
    }
}