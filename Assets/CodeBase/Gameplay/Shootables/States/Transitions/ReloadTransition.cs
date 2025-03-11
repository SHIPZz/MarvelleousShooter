using UniRx;

namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public sealed class ReloadTransition : BaseShootTransition,ITransition
    {
        private bool _reloadRequested;

        public override void Initialize()
        {
            base.Initialize();

            InputService.OnReloadPressed.Subscribe(_ => ProcessReloadRequest()).AddTo(CompositeDisposable);
        }

        public bool ShouldTransition()
        {
            return ShootService.NoAmmo
                   && !ShootService.IsReloading
                   && ShootService.Reloadable
                   || _reloadRequested;
        }

        public void MoveToTargetState()
        {
            _reloadRequested = false;
            ShootStateMachine.Enter<ReloadState>();
        }

        private void ProcessReloadRequest()
        {
            if (!ShootService.SameAmmoCount && !ShootService.IsReloading && ShootService.Reloadable)
                _reloadRequested = true;
        }
    }
}