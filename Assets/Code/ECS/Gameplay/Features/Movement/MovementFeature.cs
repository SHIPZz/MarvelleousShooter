using Code.ECS.Gameplay.Features.Movement.Jumping.Systems;
using Code.ECS.Gameplay.Features.Movement.Systems;
using Code.ECS.Gameplay.Features.Movement.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<UpdateTransformPositionSystem>());

            Add(systemFactory.Create<AllowMovementSystem>());
            Add(systemFactory.Create<AllowIdleFocusPlayingSystem>());

            Add(systemFactory.Create<MarkMovingRequestedOnInputSystem>());
            
            Add(systemFactory.Create<MarkIdleFocusUnAvailableOnAnimPlayingSystem>());
            
            Add(systemFactory.Create<MarkIdleFocusPlayingRequestedOnInput>());

            Add(systemFactory.Create<MarkMovingUnAvailableOnNoGroundSystem>());
            
            Add(systemFactory.Create<MarkIdleSystem>());
            Add(systemFactory.Create<MarkMovingSystem>());
            Add(systemFactory.Create<MarkWalkingSystem>());


            Add(systemFactory.Create<SetMovementDirectionByCameraDirectionSystem>());

            Add(systemFactory.Create<CalculateJumpVelocitySystem>());

            Add(systemFactory.Create<CalculateFinalVelocitySystem>());


            Add(systemFactory.Create<DisableMovingOnNoGround>());
            Add(systemFactory.Create<DisableRunningOnNoGroundSystem>());

            Add(systemFactory.Create<PlayIdleSystem>());
            Add(systemFactory.Create<PlayMovingSystem>());
            Add(systemFactory.Create<PlayRunningSystem>());

            Add(systemFactory.Create<CleanupJumpSystem>());
        }
    }
}