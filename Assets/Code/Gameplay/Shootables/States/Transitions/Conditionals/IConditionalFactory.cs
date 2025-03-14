namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public interface IConditionalFactory
    {
        T Get<T>() where T : ICondition;
    }
}