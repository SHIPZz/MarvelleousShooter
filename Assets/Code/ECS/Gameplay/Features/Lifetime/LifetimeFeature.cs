using Code.ECS.Gameplay.Features.Lifetime.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    public sealed class LifetimeFeature : Feature
    {
        public LifetimeFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
            Add(systemFactory.Create<MarkIsAliveSystem>());
            Add(systemFactory.Create<RestoreHpSystem>());
            Add(systemFactory.Create<UnapplyStatusesOfDeadTargetSystem>());
            Add(systemFactory.Create<CleanUpHpRestoredSystem>());
        }
    }
    
}