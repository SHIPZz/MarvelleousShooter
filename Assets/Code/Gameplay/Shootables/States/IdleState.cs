using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;

namespace Code.Gameplay.Shootables.States
{
    public sealed class IdleState : BaseShootState, IState
    {
        public IdleState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
            AddTransition<MovementTransition>();
            AddTransition<ShootTransition>();
            AddTransition<IdleFocusTransition>();
            AddTransition<AimIdleTransition>();
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            // _heroService.HeroMovement.Idle();
        }
    }
}