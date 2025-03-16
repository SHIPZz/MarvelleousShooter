using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class DisableMovingAvailableOnDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(128);

        public DisableMovingAvailableOnDeadSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Dead,
                    GameMatcher.MovingAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isMovingAvailable = false;
            }
        }
    }
}