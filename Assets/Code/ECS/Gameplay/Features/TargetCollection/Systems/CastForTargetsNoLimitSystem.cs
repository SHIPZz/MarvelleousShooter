using System.Collections.Generic;
using Code.ECS.Common.Physics;
using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsNoLimitSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IPhysicsService _physicsService;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(128);

        public CastForTargetsNoLimitSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.WorldPosition,
                    GameMatcher.Radius,
                    GameMatcher.CollectingAvailable,
                    GameMatcher.CollectTargetsLayerMask
                ).NoneOf(GameMatcher.TargetLimit));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                FillTargetsBufferByTargetsInRadius(entity);

                if (entity.TargetsBuffer.Count > 0)
                {
                    entity.ReplaceLastCollectedId(entity.TargetsBuffer[^1]);
                }

                if (!entity.isCollectingTargetsContinuously)
                    entity.isReadyToCollectTargets = false;
            }
        }


        private void FillTargetsBufferByTargetsInRadius(GameEntity entity)
        {
            IEnumerable<GameEntity> targetInRadius =
                _physicsService.CircleCast(entity.WorldPosition, entity.Radius, entity.CollectTargetsLayerMask);

            foreach (GameEntity target in targetInRadius)
            {
                if (entity.hasIgnoreBuffer && entity.IgnoreBuffer.Contains(target.Id))
                    continue;

                entity.TargetsBuffer.Add(target.Id);
            }
        }
    }
}