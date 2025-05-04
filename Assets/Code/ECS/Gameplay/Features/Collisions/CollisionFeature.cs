using Code.ECS.Gameplay.Features.Collisions.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Collisions
{
    public sealed class CollisionFeature : Feature
    {
        public CollisionFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForGroundDetectionSystem>());
        }
    }
}