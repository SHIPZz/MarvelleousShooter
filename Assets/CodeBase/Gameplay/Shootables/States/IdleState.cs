using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
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
            AddTransition<IdleFocusTransition>();
            AddTransition<AimIdleTransition>();
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            _heroService.HeroMovement.Idle();
        }
    }
}