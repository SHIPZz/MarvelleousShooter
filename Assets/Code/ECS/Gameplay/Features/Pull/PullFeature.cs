using Code.ECS.Gameplay.Features.Pull.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Pull
{
    public sealed class PullFeature : Feature
    {
        public PullFeature(ISystemFactory system)
        {
            Add(system.Create<CastInPullRadiusSystem>());
            
            Add(system.Create<MarkHolderDestructedWhenTargetsDestroyedSystem>());   
            Add(system.Create<MarkTargetPullableOnHitSystem>());   
            
            Add(system.Create<AddPullableToPullableHolderWithLimitSystem>());
            Add(system.Create<AddPullableToPullableHolderWithNoLimitSystem>());
            
            Add(system.Create<MoveToPullableHolderSystem>());   
            Add(system.Create<SequentialMoveToPullableHolderSystem>());   
            Add(system.Create<ApplySpeedUpStatusOnPullingSystem>());   
            
            Add(system.Create<MarkPullableDeadOnPullingFinishedSystem>());   
            Add(system.Create<MarkPullableDestructedOnPullingFinishedSystem>());   
        }
    }
}