using CodeBase.Gameplay.Shootables.States.Conditionals;
using UniRx;

namespace CodeBase.Gameplay.Shootables.States
{
    public class IdleFocusTransition : BaseShootTransition
    {
        private bool _focusRequested;

        public override void Initialize()
        {
            base.Initialize();

            InputService
                .OnGunFocusRequested
                .Subscribe(id => _focusRequested = true)
                .AddTo(CompositeDisposable);

            TimerService
                .Executed
                .Subscribe(_ => _focusRequested = true)
                .AddTo(CompositeDisposable);
        }

        protected override void OnAddCondition()
        {
            AddConditional<NoMouseButtonInputCondition>();
            AddConditional<HasIdleFocusCondition>();
        }

        public bool ShouldTransition()
        {
            return false;
            // return NoPressedInput()
            //        && NoMouseButtonInput()
            //        && ShootService.HasIdleFocus
            //        || _focusRequested
            //        || TimerExecuted
            //     ;
        }

        public override void MoveToTargetState()
        {
            ShootStateMachine.Enter<IdleFocusState>();

  //          OnExit();
    //        OnTimerExecuted();
        }

        // public override void OnExit()
        // {
        //     _focusRequested = false;
        // }
    }
}