using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
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