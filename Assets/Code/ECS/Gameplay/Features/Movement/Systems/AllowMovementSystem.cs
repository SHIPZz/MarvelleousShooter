using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class AllowMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public AllowMovementSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Speed,
                GameMatcher.Active,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isMovingAvailable = true;
            }
        }
    }
}