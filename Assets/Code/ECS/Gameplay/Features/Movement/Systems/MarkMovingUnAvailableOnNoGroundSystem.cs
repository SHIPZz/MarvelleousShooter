using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkMovingUnAvailableOnNoGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkMovingUnAvailableOnNoGroundSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Speed,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isMovingAvailable = entity.isOnGround;
            }
        }
    }
}