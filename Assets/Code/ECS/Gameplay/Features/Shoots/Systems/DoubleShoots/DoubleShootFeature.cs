using Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems;
using Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots.Systems.Visuals;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots
{
    public sealed class DoubleShootFeature : Feature
    {
        public DoubleShootFeature(ISystemFactory systems)
        {
            Add(systems.Create<MarkDoubleShootingRequestedOnInputSystem>());
            
            Add(systems.Create<MarkShootingUnAvailableOnDoubleShootingSystem>());
            
            Add(systems.Create<PlayDoubleShootingAnimSystem>());
            
            Add(systems.Create<CleanupDoubleShootingOnAnimEndSystem>());
        }
    }
}