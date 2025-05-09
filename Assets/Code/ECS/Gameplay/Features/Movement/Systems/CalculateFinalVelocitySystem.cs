using Code.ECS.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class CalculateFinalVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public CalculateFinalVelocitySystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;

            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Active, GameMatcher.Speed)
                .AnyOf(GameMatcher.Direction, GameMatcher.JumpVelocity));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                float deltaTime = _timeService.DeltaTime;

                Vector3 direction = entity.Direction;
                Vector3 jumpVelocity = entity.JumpVelocity;

                Vector3 targetVelocity = direction * entity.Speed + jumpVelocity;
                Vector3 currentVelocity = entity.FinalVelocity;

                float damping = 1f - Mathf.Exp(entity.Damping * deltaTime); 
                Vector3 newVelocity = Vector3.Lerp(currentVelocity, targetVelocity, damping);

                entity.ReplaceFinalVelocity(newVelocity);
            
            }
        }
    }
}