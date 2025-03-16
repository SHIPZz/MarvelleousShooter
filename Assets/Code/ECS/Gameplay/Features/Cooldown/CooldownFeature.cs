using Code.ECS.Gameplay.Features.Cooldown.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Cooldown
{
    public sealed class CooldownFeature : Feature
    {
        public CooldownFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<CalculateCooldownSystem>());
        }
    }
}