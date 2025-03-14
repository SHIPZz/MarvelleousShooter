using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public sealed class MovementTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<NoMouseButtonInputCondition>();
            AddConditional<IsShootingCondition>(true);
            AddConditional<IsAimingCondition>(true);
            AddConditional<MovingOnGroundCondition>();
            AddConditional<OnGroundCondition>();
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<MovementState>();
        }
    }
}