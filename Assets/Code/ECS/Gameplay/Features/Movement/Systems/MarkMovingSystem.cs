using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkMovingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkMovingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.MovingAvailable,
                GameMatcher.Speed,
                GameMatcher.OnGround));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isMoving = entity.Speed > 0;
            }
        }
    }
}