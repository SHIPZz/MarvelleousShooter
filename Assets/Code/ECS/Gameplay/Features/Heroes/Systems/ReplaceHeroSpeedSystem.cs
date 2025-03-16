using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes.Systems
{
    public class ReplaceHeroSpeedSystem : IExecuteSystem
    {
        private const float Speed = 1;
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _hasAxis;

        public ReplaceHeroSpeedSystem(GameContext game, InputContext input)
        {
            _hasAxis = input.GetGroup(InputMatcher.HasAxis);

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.MovingAvailable,
                    GameMatcher.OnGround,
                    GameMatcher.CharacterMovement));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (_hasAxis.count <= 0)
                {
                    entity.ReplaceSpeed(0);
                    return;
                }
                
                entity.ReplaceSpeed(Speed);
            }
        }
    }
}