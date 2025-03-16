using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkWalkingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkWalkingSystem(GameContext game)
        {
            _entities = game
                .GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Speed 
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isWalking = !entity.isRunning && entity.isMoving && entity.isOnGround;
            }
        }
    }
}