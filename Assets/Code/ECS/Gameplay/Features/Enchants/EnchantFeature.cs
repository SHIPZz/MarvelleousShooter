using Code.ECS.Gameplay.Features.Enchants.Systems;
using Code.ECS.Systems;

namespace Code.ECS.Gameplay.Features.Enchants
{
    public sealed class EnchantFeature : Feature
    {
        public EnchantFeature(ISystemFactory systemses)
        {
            Add(systemses.Create<ApplyEnchantToHolderSystem>());
        }
    }
}