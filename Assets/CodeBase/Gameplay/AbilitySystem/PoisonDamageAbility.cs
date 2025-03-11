using CodeBase.Gameplay.Common.Damage;
using UnityEngine;

namespace CodeBase.Gameplay.AbilitySystem
{
    public class PoisonDamageAbility : AbstractAbility
    {
        private PoisonDamageDealer _poisonDamage;
        public override AbilityTypeId AbilityType { get; protected set; } = AbilityTypeId.Poison;

        public override void OnGained(AbilityOwner AbilityOwner)
        {
            _poisonDamage = AbilityOwner.gameObject.AddComponent<PoisonDamageDealer>()
                ;
        }

        public override void OnLose()
        {
            Object.Destroy(_poisonDamage);
        }
    }
}