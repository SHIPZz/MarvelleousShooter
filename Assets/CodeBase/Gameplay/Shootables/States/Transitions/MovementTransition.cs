using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class MovementTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<NoMouseButtonInputCondition>();
            AddConditional<MovingOnGroundCondition>();
            AddConditional<OnGroundCondition>();
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<MovementState>();
        }
    }
}