using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Follow.Systems
{
    public class FollowTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _targets;
        private readonly GameContext _game;

        public FollowTargetSystem(GameContext game)
        {
            _game = game;

            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FollowTargetId,
                    GameMatcher.WorldPosition));

            _targets = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                GameEntity target = _game.GetEntityWithId(entity.FollowTargetId);

                if (!_targets.ContainsEntity(target))
                {
                    entity.isDestructed = true;
                    continue;
                }

                var distance = Vector3.Distance(entity.WorldPosition, target.WorldPosition);
                entity.ReplaceFollowDistanceLeft(distance);

                entity.ReplaceDirection((target.WorldPosition - entity.WorldPosition).normalized);
            }
        }
    }
}