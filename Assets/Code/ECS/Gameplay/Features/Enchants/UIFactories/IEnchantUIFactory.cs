using Code.ECS.Gameplay.Features.Enchants.Behaviours;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Enchants.UIFactories
{
    public interface IEnchantUIFactory
    {
        Enchant CreateEnchant(Transform parent, EnchantTypeId enchantTypeId);
    }
}