using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class DisableMovingOnNoGround : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(16);

        public DisableMovingOnNoGround(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Speed,
                GameMatcher.Moving,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (!entity.isOnGround)
                    entity.isMoving = false;
            }
        }
    }
}