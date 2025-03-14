using Code.Gameplay.Shootables.States.Transitions.Conditionals;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public sealed class ReloadTransition : BaseShootTransition
    {
        private bool _reloadRequested;

        protected override void OnAddCondition()
        {
            AddConditional<CanReloadCondition>();
            AddConditional<NeedReloadingCondition>();
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<ReloadState>();
        }
    }
}