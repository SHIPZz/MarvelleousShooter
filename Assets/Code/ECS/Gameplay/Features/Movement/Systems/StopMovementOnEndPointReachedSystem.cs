using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class StopMovementOnEndPointReachedSystem : IExecuteSystem
    {
        private const float MaxDistance = 0.1f;
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public StopMovementOnEndPointReachedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EndPoint,
                    GameMatcher.WorldPosition,
                    GameMatcher.Moving,
                    GameMatcher.MovingAvailable
                    ).NoneOf(GameMatcher.EndPointReached));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (Vector3.Distance(entity.WorldPosition, entity.EndPoint) <= MaxDistance)
                {
                    entity.isMoving = false;
                    entity.isMovingAvailable = false;
                    entity.isEndPointReached = true;
                }
            }
        }
    }
}