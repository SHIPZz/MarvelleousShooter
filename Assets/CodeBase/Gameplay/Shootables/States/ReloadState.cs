using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.StateMachine.Async;
using Cysharp.Threading.Tasks;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class ReloadState : BaseShootState, IState
    {
        public ReloadState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory) : base(inputService, shootService,
            shootStateMachine, heroService, transitionFactory)
        {
            
        }

        public void Enter()
        {
            TryReload();
        }

        public void Exit()
        {
            
        }

        private void EnterIdleState()
        {
            if (_shootService.IsAiming)
                _shootStateMachine.Enter<AimMovementState>();
            else
                _shootStateMachine.Enter<MovementState>();
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

                _shootService.Reload(onComplete: EnterIdleState);
            }
        }
    }
}