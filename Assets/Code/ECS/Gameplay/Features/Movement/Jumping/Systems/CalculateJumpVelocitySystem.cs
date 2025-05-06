using Code.ECS.Common.Time;
using Code.ECS.Extensions;
using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;
using KinematicCharacterController;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement.Jumping.Systems
{
    public class CalculateJumpVelocitySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<InputEntity> _inputs;
        private readonly ITimeService _timeService;

        public CalculateJumpVelocitySystem(GameContext game, InputContext input, ITimeService timeService)
        {
            _timeService = timeService;
            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input));

            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.BaseStats,
                GameMatcher.JumpForce));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity entity in _entities)
            {
                float jumpForce = entity.BaseStats[Stats.JumpForce];
                float verticalVelocity = entity.VerticalVelocity;

                if (input.isJumpingRequested && entity.isOnGround)
                {
                    verticalVelocity = jumpForce;
                }
                else if (!input.isJumpingRequested && entity.isOnGround)
                {
                    verticalVelocity = 0;
                }

                if (!entity.isOnGround)
                {
                    verticalVelocity += entity.Gravity * _timeService.DeltaTime;
                }

                entity.isJumpingRequested = true;
                entity.isJumping = true;

                if (verticalVelocity > 0)
                    entity.isOnGround = false;

                entity.ReplaceVerticalVelocity(verticalVelocity);
                entity.ReplaceJumpVelocity(new Vector3(0, entity.VerticalVelocity, 0));
            }
        }
    }
}