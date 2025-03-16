using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Follow.Systems
{
    public class MarkFollowingUpWithoutMaxDistanceSystem : IExecuteSystem
    {
        private const float MinDistance = 0.1f;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(123);

        public MarkFollowingUpWithoutMaxDistanceSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FollowTargetId,
                    GameMatcher.FollowDistanceLeft));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isFollowingUp = entity.FollowDistanceLeft <= MinDistance;

                if (entity.isFollowingUp)
                {
                    entity.RemoveFollowDistanceLeft();
                    entity.isMoving = false;
                }
            }
        }
    }
}