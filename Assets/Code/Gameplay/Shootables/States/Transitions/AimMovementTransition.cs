using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
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