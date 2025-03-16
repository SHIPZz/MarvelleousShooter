using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MoveYBySinCurveSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public MoveYBySinCurveSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.AnimationDuration,
                    GameMatcher.AnimationCurve,
                    GameMatcher.ElapsedTime,
                    GameMatcher.StartHeight,
                    GameMatcher.Moving,
                    GameMatcher.UpdateHeightBySinCurve
                ).NoneOf(GameMatcher.HeightUpdated));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                var position = entity.WorldPosition;
                var animationDuration = entity.AnimationDuration;
                var elapsedTime = entity.ElapsedTime;

                elapsedTime += Time.deltaTime;

                if (elapsedTime >= animationDuration)
                {
                    entity.isHeightUpdated = true;
                    continue;
                }
                
                float normalizedTime = (elapsedTime % animationDuration) / animationDuration;
                float yOffset = entity.AnimationCurve.Evaluate(normalizedTime); 
                
                entity.ReplaceWorldPosition(new Vector3(
                    position.x,
                    entity.StartHeight + yOffset,
                    position.z
                ));

                entity.ReplaceElapsedTime(elapsedTime);
            }
        }
    }
}