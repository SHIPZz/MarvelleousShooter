using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;

namespace Code.Gameplay.Shootables.States
{
    public sealed class ReloadState : BaseShootState, IState
    {
        public ReloadState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
            AddTransition<IdleTransition>();
            AddTransition<AimMovementTransition>();
            AddTransition<AimIdleTransition>();
            AddTransition<MovementTransition>();
            AddTransition<ShootTransition>();
        }

        public void Enter()
        {
            // TransitionAvailable = false;
            // TryReload();
        }

        public void Exit()
        {
            // _shootService.CurrentShoot.MarkShootingAvailable(true);
        }

        private void TryReload()
        {
            if (!_shootService.Reloadable)
                return;

            if (!_shootService.IsReloading && !_shootService.SameAmmoCount)
            {
                // _heroService.HeroMovement.StopAll();
                _shootService.Aimer.StopAim();
                _shootService.CurrentShoot.StopShooting();
                _shootService.CurrentShoot.MarkShootingAvailable(false);
                _shootService.Reload(onComplete: () => TransitionAvailable = true);
            }
        }
    }
}