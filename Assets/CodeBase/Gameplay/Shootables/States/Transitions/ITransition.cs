namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public interface ITransition
    {
        bool ShouldTransition();
        void MoveToTargetState();
    }
}