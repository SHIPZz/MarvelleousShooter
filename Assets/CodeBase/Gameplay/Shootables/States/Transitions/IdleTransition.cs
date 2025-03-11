using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class IdleTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<IsShootingCondition>(true);
            AddConditional<IsAimingCondition>(true);
            AddConditional<HasAxisInputConditional>(true);
        }

        protected override void OnAddOrCondition()
        {
            base.OnAddOrCondition();
            
            AddOrConditional<OnGroundCondition>(true);
            AddOrConditional<IsShootingCondition>(true);
            AddOrConditional<IsAimingCondition>(true);
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleState>();
        }
    }
}