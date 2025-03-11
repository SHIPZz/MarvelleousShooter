namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class ShootTransition : BaseShootTransition,ITransition
    {
        public bool ShouldTransition()
        {
            return CanNoAimShoot() || CanShootOnAir();
        }

        public void MoveToTargetState()
        {
            ShootStateMachine.Enter<ShootState>();
        }
    }
}