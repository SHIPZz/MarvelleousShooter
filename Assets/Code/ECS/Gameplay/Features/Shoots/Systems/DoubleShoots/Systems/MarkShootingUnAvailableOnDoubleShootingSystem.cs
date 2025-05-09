using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems
{
    public class MarkShootingUnAvailableOnDoubleShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingUnAvailableOnDoubleShootingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.DoubleShootingAvailable,
                    GameMatcher.DoubleShooting,
                    GameMatcher.DoubleShootRequested,
                    GameMatcher.Shootable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingAvailable = false;
            }
        }
    }
}