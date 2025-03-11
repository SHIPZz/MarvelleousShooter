namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public interface IConditionalFactory
    {
        T Get<T>() where T : ICondition;
    }
}