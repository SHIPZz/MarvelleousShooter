using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.ECS.Gameplay.Features.Enchants.Behaviours
{
    public class EnchantHolder : MonoBehaviour
    {
        public Transform EnchantLayout;
        private IEnchantUIFactory _enchantUIFactory;

        private List<Enchant> _enchants = new();

        [Inject]
        private void Construct(IEnchantUIFactory enchantUIFactory)
        {
            _enchantUIFactory = enchantUIFactory;
        }
        
        public void AddEnchant(EnchantTypeId enchantTypeId)
        {
            if(EnchantAlreadyHeld(enchantTypeId))
                return;
            
            Enchant enchant = _enchantUIFactory.CreateEnchant(EnchantLayout, enchantTypeId);

            _enchants.Add(enchant);
        }

        public void RemoveEnchant(EnchantTypeId enchantTypeId)
        {
            Enchant enchant = _enchants.Find(x => x.Id == enchantTypeId);

            if(enchant is null)
                return;
            
            _enchants.Remove(enchant);
            Destroy(enchant.gameObject);
        }

        private bool EnchantAlreadyHeld(EnchantTypeId enchantTypeId)
        {
            return _enchants.Find(x => x.Id == enchantTypeId) != null;
        }
    }
}