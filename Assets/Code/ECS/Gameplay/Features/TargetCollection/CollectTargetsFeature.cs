using Code.ECS.Gameplay.Features.TargetCollection.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.TargetCollection
{
    public sealed class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DestructOnTargetBufferLimitReachedSystem>());
            
            Add(systemFactory.Create<CollectTargetsIntervalSystem>());
            
            Add(systemFactory.Create<CastForTargetsNoLimitSystem>());
            Add(systemFactory.Create<CastForTargetsWithLimitSystem>());
            Add(systemFactory.Create<MarkReachedSystem>());
            
            Add(systemFactory.Create<CleanupTargetBuffersSystem>());
        }
    }
}