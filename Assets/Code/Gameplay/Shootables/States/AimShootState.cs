using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;

namespace Code.Gameplay.Shootables.States
{
    public class AimShootState : BaseShootState, IState
    {
        public AimShootState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
            AddTransition<ShootTransition>();
            AddTransition<AimMovementTransition>();
            AddTransition<MovementTransition>();
            AddTransition<AimIdleTransition>();
        }

        public void Enter()
        {
            _shootService.CurrentShoot.StartShooting();
        }

        public void Exit()
        {
            if (!_inputService.IsAiming())
                _shootService.Aimer.StopAim();

            _shootService.CurrentShoot.StopShooting();
        }
    }
}