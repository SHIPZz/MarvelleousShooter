using System;

namespace Code.Gameplay.AbilitySystem.StatSystem.StatModifiers
{
    public static class StatModifierExtensions
    {
        public static StatTypeId GetStatTypeId(this AbilityTypeId abilityTypeId)
        {
            switch (abilityTypeId)
            {
                case AbilityTypeId.TemporaryDamageIncrease:
                    return StatTypeId.Damage;

                case AbilityTypeId.DoubleShot:
                    return StatTypeId.Damage;

                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityTypeId), $"Unhandled AbilityTypeId: {abilityTypeId}");
            }
        }
    }
}