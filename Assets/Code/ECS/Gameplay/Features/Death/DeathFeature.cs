using Code.ECS.Gameplay.Features.Death.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Death
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MarkDeadSystem>());
            Add(systemFactory.Create<UnapplyStatusesOfDeadTargetSystem>());
        }
    }
}