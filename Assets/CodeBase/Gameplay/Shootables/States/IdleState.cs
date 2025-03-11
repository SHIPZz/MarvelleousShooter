using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class IdleState : BaseShootState, IState
    {
        public IdleState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory) : base(inputService, shootService,
            shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<MovementTransition>();
            AddTransition<ShootTransition>();
            AddTransition<AimIdleTransition>();
        }

        public void Exit()
        {
            _heroService.HeroMovement.StopIdle();
        }

        public void Enter()
        {
            _heroService.HeroMovement.Idle();
        }
    }
}