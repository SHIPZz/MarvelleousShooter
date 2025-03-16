using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Follow.Systems
{
    public class MarkFollowingUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(123);

        public MarkFollowingUpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FollowTargetId,
                    GameMatcher.FollowDistanceLeft,
                    GameMatcher.FollowMaxDistance
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isFollowingUp = entity.FollowDistanceLeft <= entity.FollowMaxDistance;

                if (entity.isFollowingUp)
                {
                    entity.RemoveFollowDistanceLeft();
                    entity.isMoving = false;
                }
            }
        }
    }
}