using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
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