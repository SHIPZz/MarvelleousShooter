using Code.ECS.Gameplay.Features.Follow.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Follow
{
    public sealed class FollowTargetFeature : Feature
    {
        public FollowTargetFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<FollowTargetSystem>());
            Add(systemFactory.Create<UpdateLastFollowTargetsSystem>());
            Add(systemFactory.Create<MarkFollowingUpSystem>());
            Add(systemFactory.Create<MarkFollowingUpWithoutMaxDistanceSystem>());
            Add(systemFactory.Create<SetNewFollowTargetOnFollowingUpSystem>());
        }
    }
}