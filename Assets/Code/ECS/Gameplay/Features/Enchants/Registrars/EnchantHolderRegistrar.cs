using Code.ECS.Gameplay.Features.Enchants.Behaviours;
using Code.ECS.View.Registrars;

namespace Code.ECS.Gameplay.Features.Enchants.Registrars
{
    public class EnchantHolderRegistrar : EntityComponentRegistrar
    {
        public EnchantHolder EnchantHolder;
        
        public override void RegisterComponents()
        {
            Entity.AddEnchantHolder(EnchantHolder);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveEnchantHolder();
        }
    }
}