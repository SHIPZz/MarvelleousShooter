using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkShootingStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingStartedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingStarted = entity.isShootingContinuously;
            }
        }
    }
}