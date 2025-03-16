using Code.ECS.Gameplay.Features.Movement.Systems;
using Code.ECS.Gameplay.Features.Movement.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Movement
{
    public sealed class MovementFeature : Feature
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkIdleSystem>());
            Add(systemFactory.Create<MarkMovingSystem>());
            Add(systemFactory.Create<MarkWalkingSystem>());
            Add(systemFactory.Create<MarkMovingUnAvailableOnNoGroundSystem>());
            Add(systemFactory.Create<SetSpeedZeroOnNoGroundSystem>());
            Add(systemFactory.Create<DisableMovingOnNoGround>());
            Add(systemFactory.Create<PlayIdleSystem>());
            Add(systemFactory.Create<PlayMovingSystem>());
            Add(systemFactory.Create<PlayRunningSystem>());
        }
    }
}