using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.AbilitySystem
{
    public class AbilityOwner : MonoBehaviour
    {
        [field: SerializeField] public AbilityOwnerTypeId Id { get; private set; }

        private readonly Dictionary<AbilityTypeId, AbstractAbility> _abilities = new(32);

        private void Update()
        {
            foreach (AbstractAbility ability in _abilities.Values)
            {
                ability.OnUpdate();
            }
        }

        public void AddAbility(AbstractAbility ability)
        {
            _abilities[ability.AbilityType] = ability;
            ability.OnGained(this);
        }

        public void RemoveAbility(AbilityTypeId abilityTypeId)
        {
            AbstractAbility abstractAbility = _abilities[abilityTypeId];
            _abilities.Remove(abstractAbility.AbilityType);
            abstractAbility.OnLose();
        }
    }
}