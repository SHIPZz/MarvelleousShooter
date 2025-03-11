using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class AimMovementState : BaseShootState, IState
    {
        public AimMovementState(IInputService inputService, IShootService shootService,
            IShootStateMachine shootStateMachine, IHeroService heroService, ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<AimShootTransition>();
            AddTransition<AimIdleTransition>();
            AddTransition<MovementTransition>();
        }

        public void Exit()
        {
            _shootService.Aimer.StopAim();
        }
        
        public void Enter()
        {
            _shootService.Aimer.Aim();
            _heroService.HeroMovement.Walk();
        }
    }
}