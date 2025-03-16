using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkIdleSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkIdleSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.IdleAvailable,
                    GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isIdle = !entity.isMoving;
            }
        }
    }
}