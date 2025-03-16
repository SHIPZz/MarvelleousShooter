using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Follow.Systems
{
    public class SetNewFollowTargetOnFollowingUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _enemies;
        private readonly List<GameEntity> _buffer = new(128);

        public SetNewFollowTargetOnFollowingUpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.FollowTargetId,
                    GameMatcher.FollowNewCloseTarget,
                    GameMatcher.LastFollowTargets,
                    GameMatcher.FollowingUp));

            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Id,
                GameMatcher.Enemy,
                GameMatcher.Alive,
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                GameEntity closestTarget = GetClosestTarget(entity);

                if (closestTarget == null)
                {
                    entity.isDestructed = true;
                    continue;
                }

                entity.ReplaceFollowTargetId(closestTarget.Id);
            }
        }

        private GameEntity GetClosestTarget(GameEntity entity)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            foreach (GameEntity enemy in _enemies)
            {
                if (entity.LastFollowTargets.Contains(enemy.Id))
                    continue;

                float distanceToTarget = Vector3.Distance(enemy.WorldPosition, entity.WorldPosition);

                if (distanceToTarget <= maxDistance)
                {
                    maxDistance = distanceToTarget;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }
    }
}