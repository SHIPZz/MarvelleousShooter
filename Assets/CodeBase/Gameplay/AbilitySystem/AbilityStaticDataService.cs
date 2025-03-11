using System.Collections.Generic;
using System.Linq;
using CodeBase.Constant;
using UnityEngine;

namespace CodeBase.Gameplay.AbilitySystem
{
    public interface IAbilityStaticDataService
    {
        AbilityConfig Get(AbilityTypeId id);
    }

    public class AbilityStaticDataService : IAbilityStaticDataService
    {
        private readonly Dictionary<AbilityTypeId, AbilityConfig> _abilityConfigs;

        public AbilityStaticDataService()
        {
            _abilityConfigs = Resources.LoadAll<AbilityConfig>(AssetPath.Abilities)
                .ToDictionary(x => x.AbilityTypeId, x => x);
        }

        public AbilityConfig Get(AbilityTypeId id) => _abilityConfigs[id];
    }
}