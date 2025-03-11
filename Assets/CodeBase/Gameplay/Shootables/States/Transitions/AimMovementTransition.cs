using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class AimMovementTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<IsAimingCondition>();
            AddConditional<MovingOnGroundCondition>();
            AddConditional<IsShootingCondition>(true);
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<AimMovementState>();
        }
    }
}