using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class ReplaceHeroSpeedOnInputSystem : IExecuteSystem
    {
        private const float Speed = 1;
        
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _hasAxis;

        public ReplaceHeroSpeedOnInputSystem(GameContext game, InputContext input)
        {
            _hasAxis = input.GetGroup(InputMatcher.HasAxis);

            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.MovingAvailable,
                    GameMatcher.OnGround,
                    GameMatcher.CharacterMovement));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.ReplaceSpeed(_hasAxis.count > 0 ? Speed : 0);
            }
        }
    }
}