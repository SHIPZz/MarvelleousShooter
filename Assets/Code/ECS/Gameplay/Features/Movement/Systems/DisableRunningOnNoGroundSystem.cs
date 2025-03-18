using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class DisableRunningOnNoGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DisableRunningOnNoGroundSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CanRun));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isRunningAvailable = entity.isOnGround;
                
                if(entity.isRunning && !entity.isOnGround)
                    entity.isRunning = false;   
            }
        }
    }
}