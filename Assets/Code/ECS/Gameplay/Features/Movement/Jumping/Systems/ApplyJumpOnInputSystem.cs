using Code.Constant;
using Code.ECS.Common.Time;
using Code.ECS.Extensions;
using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Jumping.Systems
{
    public class ApplyJumpOnInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _jumpingRequested;
        private readonly ITimeService _timeService;

        public ApplyJumpOnInputSystem(GameContext game, InputContext input, ITimeService timeService)
        {
            _timeService = timeService;
            _jumpingRequested = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.JumpingRequested));

            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.BaseStats,
                GameMatcher.JumpForce));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                float jumpForce = entity.BaseStats[Stats.JumpForce];
                float velocity = entity.VerticalVelocity;
                
                if (_jumpingRequested.count > 0 && entity.isOnGround)
                {
                    velocity = jumpForce;
                }
                
                if (!entity.isOnGround)
                {
                    velocity += entity.Gravity * _timeService.DeltaTime;
                }
                else if(entity.isOnGround && _jumpingRequested.count <= 0 && entity.VerticalVelocity < -5f)
                {
                    velocity = 0;
                }

                entity.isJumpingRequested = true;
                entity.isJumping = true;

                entity.ReplaceVerticalVelocity(velocity);
                entity.ReplaceDirection(entity.Direction.SetY(entity.VerticalVelocity));
            }
        }
    }
}