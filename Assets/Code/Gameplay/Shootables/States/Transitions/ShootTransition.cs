using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public sealed class ShootTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<IsShootingCondition>();
            AddConditional<IsAimingCondition>(true);
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<ShootState>();
        }
    }
}