using Code.Gameplay.Shootables.States.Transitions;
using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States
{
    public class JumpTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<OnGroundCondition>(true);
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleState>();
        }
    }
}