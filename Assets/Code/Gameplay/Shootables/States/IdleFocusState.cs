using System;
using Code.Gameplay.Common.Timer;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using UniRx;

namespace Code.Gameplay.Shootables.States
{
    public class IdleFocusState : BaseShootState, IState, IDisposable
    {
        private readonly IShootFocusService _shootFocusService;
        private readonly CompositeDisposable _compositeDisposable = new();

        public IdleFocusState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
            // _shootFocusService = shootFocusService;
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

            // _shootService.Animator.StartIdleFocus();
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