using CodeBase.Gameplay.AbilitySystem.StatSystem;
using CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers;

namespace CodeBase.Gameplay.AbilitySystem
{
    public class TemporaryIncreaseDamageAbility : AbstractAbility
    {
        private Stats _stats;
        private StatModifier _statModifier;
        
        public override AbilityTypeId AbilityType { get; protected set; } = AbilityTypeId.TemporaryDamageIncrease;
        
        public override void OnGained(AbilityOwner AbilityOwner)
        {
             _stats = AbilityOwner.GetComponent<Stats>();
             _statModifier = new StatModifier(StatTypeId.Damage, 5f);
             _stats.AddModifier(_statModifier);
        }

        public override void OnLose()
        {
            _stats.RemoveModifier(_statModifier);
        }
    }
}