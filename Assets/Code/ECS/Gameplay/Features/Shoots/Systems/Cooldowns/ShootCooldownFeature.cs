using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cooldowns
{
    public sealed class ShootCooldownFeature : Feature
    {
        public ShootCooldownFeature(ISystemFactory systems)
        {
            Add(systems.Create<ReplaceShootCooldownLeftOnShootSystem>());
            Add(systems.Create<CalculateShootCooldownSystem>());
            Add(systems.Create<MarkShootCooldownProcessingOnShootSystem>());
        }
    }
}