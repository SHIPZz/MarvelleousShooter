using CodeBase.Gameplay.Shootables.States.Conditionals;
using UniRx;

namespace CodeBase.Gameplay.Shootables.States
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