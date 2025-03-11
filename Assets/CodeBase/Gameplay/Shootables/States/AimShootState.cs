using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class AimShootState : BaseShootState, IState
    {
        public AimShootState(IInputService inputService, IShootService shootService,
            IShootStateMachine shootStateMachine, IHeroService heroService, ITransitionFactory transitionFactory)
            : base(inputService, shootService, shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<ShootTransition>();
            AddTransition<AimMovementTransition>();
            AddTransition<MovementTransition>();
            AddTransition<AimIdleTransition>();
        }

        public void Enter()
        {
            _shootService.Aimer.Aim();
            _shootService.CurrentShoot.StartShooting();
        }

        public void Exit()
        {
            if (!_inputService.IsAiming())
                _shootService.Aimer.StopAim();

            if (!_inputService.IsShooting())
                _shootService.CurrentShoot.StopShooting();
        }
    }
}