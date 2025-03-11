namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class MovementTransition : BaseShootTransition,ITransition
    {
        public bool ShouldTransition()
        {
            return NoMouseButtonInput() && HasMoveOnGroundInput();
        }

        public  void MoveToTargetState()
        {
            ShootStateMachine.Enter<MovementState>();
        }
    }
}