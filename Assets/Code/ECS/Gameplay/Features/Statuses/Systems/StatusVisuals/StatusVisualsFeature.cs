using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Statuses.Systems.StatusVisuals
{
    public class StatusVisualsFeature : Feature
    {
        public StatusVisualsFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ApplyPoisonVisualsSystem>());
            Add(systemFactory.Create<ApplyFreezeVisualsSystem>());
            
            Add(systemFactory.Create<UnapplyPoisonVisualsSystem>());
            Add(systemFactory.Create<UnapplyFreezeVisualsSystem>());
        }
    }
}