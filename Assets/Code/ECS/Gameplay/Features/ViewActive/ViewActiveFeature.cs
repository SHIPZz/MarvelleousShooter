using Code.ECS.Gameplay.Features.ViewActive.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.ViewActive
{
    public sealed class ViewActiveFeature : Feature
    {
        public ViewActiveFeature(ISystemFactory systems)
        {
            Add(systems.Create<SetActiveViewSystem>());
        }
    }
}