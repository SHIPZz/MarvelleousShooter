using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class AimIdleState : BaseShootState, IState
    {
        public AimIdleState(IInputService inputService, IShootService shootService,
            IShootStateMachine shootStateMachine, IHeroService heroService, ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<IdleTransition>();
            AddTransition<AimShootTransition>();
            AddTransition<AimMovementTransition>();
        }

        public void Enter()
        {
            _shootService.Aimer.Aim();
            _heroService.HeroMovement.StopAll();
        }

        public void Exit()
        {
            _shootService.Aimer.StopAim();
        }
    }
}