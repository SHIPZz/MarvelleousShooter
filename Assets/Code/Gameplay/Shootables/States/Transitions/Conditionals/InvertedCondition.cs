namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
{
    public class InvertedCondition : ICondition
    {
        private readonly ICondition _condition;

        public InvertedCondition(ICondition condition)
        {
            _condition = condition;
        }

        public bool IsMet() => !_condition.IsMet();
    }
}