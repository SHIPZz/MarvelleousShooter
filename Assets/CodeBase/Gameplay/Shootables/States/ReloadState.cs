using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class ReloadState : BaseShootState, IState
    {
        public ReloadState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory) : base(inputService, shootService,
            shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<IdleTransition>();
            AddTransition<AimMovementTransition>();
            AddTransition<AimIdleTransition>();
            AddTransition<MovementTransition>();
            AddTransition<ShootTransition>();
        }

        public void Enter()
        {
            TransitionAvailable = false;
            TryReload();
        }

        public void Exit()
        {
            _shootService.CurrentShoot.MarkShootingAvailable(true);
        }

        private void TryReload()
        {
            if (!_shootService.Reloadable)
                return;

            if (!_shootService.IsReloading && !_shootService.SameAmmoCount)
            {
                _heroService.HeroMovement.StopAll();
                _shootService.Aimer.StopAim();
                _shootService.CurrentShoot.StopShooting();
                _shootService.CurrentShoot.MarkShootingAvailable(false);
                _shootService.Reload(onComplete: () => TransitionAvailable = true);
            }
        }
    }
}