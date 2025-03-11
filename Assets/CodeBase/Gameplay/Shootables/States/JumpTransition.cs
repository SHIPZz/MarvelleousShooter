using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
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