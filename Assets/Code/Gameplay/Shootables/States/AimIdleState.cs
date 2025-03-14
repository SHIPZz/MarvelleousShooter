using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;

namespace Code.Gameplay.Shootables.States
{
    public class AimIdleState : BaseShootState, IState
    {
        public AimIdleState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
            AddTransition<IdleTransition>();
            AddTransition<AimShootTransition>();
            AddTransition<AimMovementTransition>();
        }

        public void Enter()
        {
            _shootService.Aimer.Idle();
            // _heroService.HeroMovement.StopAll();
        }

        public void Exit()
        {
            _shootService.Aimer.StopAim();
        }
    }
}