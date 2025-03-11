namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class AimShootTransition : BaseShootTransition, ITransition
    {
        public bool ShouldTransition()
        {
            return CanAimShoot();
        }

        public void MoveToTargetState()
        {
            ShootStateMachine.Enter<AimShootState>();
        }
    }
}