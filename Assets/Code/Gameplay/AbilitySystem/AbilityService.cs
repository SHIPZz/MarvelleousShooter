using System.Collections.Generic;
using Zenject;

namespace Code.Gameplay.AbilitySystem
{
    public class AbilityService : IAbilityService, ITickable
    {
        private readonly Dictionary<AbilityOwnerTypeId, AbilityOwner> _abilityOwners = new();
        private Dictionary<AbilityTypeId, AbstractAbility> _activeAbilities = new(32);

        private readonly IAbilityFactory _abilityFactory;

        public AbilityService(IAbilityFactory abilityFactory)
        {
            _abilityFactory = abilityFactory;
        }

        public void Init()
        {
        }

        public void AddAbilityOwner(AbilityOwner abilityOwner)
        {
            _abilityOwners[abilityOwner.Id] = abilityOwner;
        }

        public void RemoveAbilityOwner(AbilityOwner abilityOwner)
        {
            _abilityOwners.Remove(abilityOwner.Id);
        }
        
        public void Start<T>(AbilityOwnerTypeId abilityOwnerTypeId = AbilityOwnerTypeId.Player) where T : AbstractAbility
        {
            var abstractAbility = _abilityFactory.CreateAbility<T>();
            _abilityOwners[abilityOwnerTypeId].AddAbility(abstractAbility);
            _activeAbilities[abstractAbility.AbilityType] = abstractAbility;
        }

        public void Stop(AbilityTypeId abilityTypeId, AbilityOwnerTypeId abilityOwnerTypeId = AbilityOwnerTypeId.Player)
        {
            _abilityOwners[abilityOwnerTypeId].RemoveAbility(abilityTypeId);
            _activeAbilities.Remove(abilityTypeId);
        }

        public void Tick()
        {
            foreach (AbstractAbility abilitySystem in _activeAbilities.Values)
            {
                
            }
        }
    }
}