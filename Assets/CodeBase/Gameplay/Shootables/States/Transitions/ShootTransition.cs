using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
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