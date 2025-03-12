using System;
using CodeBase.Gameplay.Common.Timer;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using UniRx;

namespace CodeBase.Gameplay.Shootables.States
{
    public class IdleFocusState : BaseShootState, IState, IDisposable
    {
        private readonly IShootFocusService _shootFocusService;
        private readonly CompositeDisposable _compositeDisposable = new();

        public IdleFocusState(IInputService inputService,
            IShootService shootService,
            IShootStateMachine shootStateMachine,
            IHeroService heroService,
            IShootFocusService shootFocusService,
            ITimerService timerService,
            ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            _shootFocusService = shootFocusService;
            AddTransition<IdleTransition>();
            AddTransition<ShootTransition>();
            AddTransition<AimIdleTransition>();
            AddTransition<MovementTransition>();
        }

        protected override void OnUpdate()
        {
            if (_inputService.IsShooting())
            {
                TransitionAvailable = true;
                _shootFocusService.StopFocusing();
            }
        }

        public void Enter()
        {
            TransitionAvailable = false;

            _shootFocusService.Stopped.Subscribe(_ => SetTransitionAvailable()).AddTo(_compositeDisposable);

            _shootService.Animator.StartIdleFocus();
        }

        private void SetTransitionAvailable()
        {
            TransitionAvailable = true;
        }

        public void Exit()
        {
            TransitionAvailable = true;
        }

        public void Dispose()
        {
            _compositeDisposable?.Dispose();
        }
    }
}