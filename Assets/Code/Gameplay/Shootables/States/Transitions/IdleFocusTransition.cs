using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public class IdleFocusTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            AddConditional<NoMouseButtonInputCondition>();
            AddConditional<HasIdleFocusCondition>();
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleFocusState>();
        }
    }
}