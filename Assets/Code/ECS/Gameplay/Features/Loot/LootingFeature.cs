using Code.ECS.Gameplay.Features.Loot.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Loot
{
    public sealed class LootingFeature : Feature
    {
        public LootingFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CollectWhenNearSystem>());
            
            Add(systemFactory.Create<CollectStatusItemSystem>());
            Add(systemFactory.Create<CollectEffectItemSystem>());
            
            Add(systemFactory.Create<CleanupCollectedSystem>());
        }
    }
}