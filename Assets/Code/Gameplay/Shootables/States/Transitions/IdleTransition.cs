using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public sealed class IdleTransition : BaseShootTransition
    {
        private readonly List<ICondition> _orConditions = new();

        protected override void OnAddCondition()
        {
            base.OnAddCondition();
            
            AddConditional<IsShootingCondition>(true);
            AddConditional<IsAimingCondition>(true);
            AddConditional<HasAxisInputConditional>(true);
        }

        protected override void OnInitialize()
        {
            _orConditions.Add(GetInvertedCondition<OnGroundCondition>());
            _orConditions.Add(GetInvertedCondition<IsShootingCondition>());
            _orConditions.Add(GetInvertedCondition<IsAimingCondition>());
        }

        public override bool ShouldTransition()
        {
            return base.ShouldTransition() || (_orConditions.Count > 0 && _orConditions.All(x => x.IsMet()));;
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleState>();
        }
    }
}