using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public sealed class AimIdleTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();

            AddConditional<MovingOnGroundCondition>(true);
            AddConditional<IsAimingCondition>();
            AddConditional<IsShootingCondition>(true);
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<AimIdleState>();
        }
    }
}