using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class MarkHeroRunningSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _runningPressed;

        public MarkHeroRunningSystem(GameContext game, InputContext input)
        {
            _runningPressed = input.GetGroup(InputMatcher.RunningPressed);
            
            _heroes = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero,
                GameMatcher.CanRun,
                GameMatcher.Speed,
                GameMatcher.MovingAvailable,
                GameMatcher.RunningAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (_runningPressed.count <= 0)
                {
                    hero.isRunning = false;
                    continue;
                }

                hero.isRunning = hero.Speed > 0;
            }
        }
    }
}