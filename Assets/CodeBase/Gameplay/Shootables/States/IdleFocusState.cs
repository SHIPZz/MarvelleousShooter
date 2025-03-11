using CodeBase.Gameplay.Common.Timer;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class IdleFocusState : BaseShootState, IState
    {
        private ITimerService _timerService;

        public IdleFocusState(IInputService inputService,
            IShootService shootService,
            IShootStateMachine shootStateMachine,
            IHeroService heroService,
            ITimerService timerService,
            ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            _timerService = timerService;
            AddTransition<IdleTransition>();
            AddTransition<ShootTransition>();
            AddTransition<AimIdleTransition>();
            AddTransition<MovementTransition>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }

        public void Enter()
        {
            _shootService.IsFocusing = true;
            _shootService.Animator.StartIdleFocus();
        }

        public void Exit()
        {
            _shootService.IsFocusing = false;
        }
    }
}