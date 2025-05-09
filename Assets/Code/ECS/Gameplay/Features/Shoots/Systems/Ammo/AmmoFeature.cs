using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Ammo
{
    public sealed class AmmoFeature : Feature
    {
        public AmmoFeature(ISystemFactory systems)
        {
            Add(systems.Create<CalculateAmmoCountOnShootSystem>());
            Add(systems.Create<MarkAmmoDecreasedSystem>());
            Add(systems.Create<MarkAmmoAvailableSystem>());
        }
    }
}