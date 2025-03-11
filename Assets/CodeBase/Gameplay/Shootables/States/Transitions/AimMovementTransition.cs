namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class AimMovementTransition : BaseShootTransition, ITransition
    {
        public bool ShouldTransition()
        {
            return IsAimingWithAxisInput()
                   && OnGround()
                   && !Shooting();
        }

        public void MoveToTargetState()
        {
            ShootStateMachine.Enter<AimMovementState>();
        }
    }
}