namespace CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers
{
    public struct StatModifier
    {
        public readonly StatTypeId StatTypeId;
        public readonly float Value;

        public StatModifier(StatTypeId statTypeId, float value)
        {
            StatTypeId = statTypeId;
            Value = value;
        }
    }
}