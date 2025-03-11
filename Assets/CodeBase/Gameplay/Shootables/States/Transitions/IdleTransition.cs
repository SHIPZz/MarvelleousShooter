namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class IdleTransition : BaseShootTransition,ITransition
    {
        public bool ShouldTransition()
        {
            return NoPressedInput() || !OnGround() && NoMouseButtonInput();
        }

        public void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleState>();
        }
    }
}