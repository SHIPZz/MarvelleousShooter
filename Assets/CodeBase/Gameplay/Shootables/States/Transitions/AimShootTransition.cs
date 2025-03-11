using CodeBase.Gameplay.Shootables.States.Conditionals;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class AimShootTransition : BaseShootTransition
    {
        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<IsAimingCondition>();
            AddConditional<IsShootingCondition>();
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<AimShootState>();
        }
    }
}