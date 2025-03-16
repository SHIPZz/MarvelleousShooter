using System;
using System.Collections.Generic;
using Code.ECS.Common.Physics;
using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IPhysicsService _physicsService;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(128);
        private GameEntity[] _targetCastBuffer = new GameEntity[128];

        public CastForTargetsWithLimitSystem(GameContext game, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TargetsBuffer,
                    GameMatcher.ReadyToCollectTargets,
                    GameMatcher.WorldPosition,
                    GameMatcher.TargetLimit,
                    GameMatcher.ProcessedTargetsBuffer,
                    GameMatcher.Radius,
                    GameMatcher.CollectingAvailable,
                    GameMatcher.CollectTargetsLayerMask
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                for (int i = 0; i < Math.Min(TargetCountInRadius(entity), entity.TargetLimit); i++)
                {
                    int targetId = _targetCastBuffer[i].Id;

                    if (!AlreadyProcessed(entity, targetId))
                    {
                        entity.TargetsBuffer.Add(targetId);
                        entity.ProcessedTargetsBuffer.Add(targetId);
                        entity.ReplaceLastCollectedId(targetId);
                    }
                }

                if (!entity.isCollectingTargetsContinuously)
                    entity.isReadyToCollectTargets = false;
            }
        }

        private bool AlreadyProcessed(GameEntity entity, int targetId)
        {
            return entity.ProcessedTargetsBuffer.Contains(targetId) || (entity.hasIgnoreBuffer && entity.IgnoreBuffer.Contains(targetId));
        }

        private int TargetCountInRadius(GameEntity entity)
        {
            return _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.Radius,
                entity.CollectTargetsLayerMask, _targetCastBuffer);
        }

        public void TearDown()
        {
            _targetCastBuffer = null;
        }
    }
}