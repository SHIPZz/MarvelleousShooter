using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class DisableRunningOnNoGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DisableRunningOnNoGroundSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CanRun,GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isOnGround)
                {
                    entity.isRunningAvailable = false;
                    entity.isRunning = false;
                }
            }
        }
    }
}