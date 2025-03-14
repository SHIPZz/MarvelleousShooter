namespace Code.Gameplay.AbilitySystem.StatSystem.StatModifiers
{
    public interface IStatService
    {
        float GetStatValue(StatTypeId statTypeId);
        void Add(Stats stats);
    }
}