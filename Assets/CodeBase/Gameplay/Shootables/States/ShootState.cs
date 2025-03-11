using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.Gameplay.Shootables.Visuals;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.StateMachine.Async;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.States
{
    public class ShootState : BaseShootState, IState
    {
        public ShootState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory) : base(inputService, shootService,
            shootStateMachine, heroService, transitionFactory)
        {
            AddTransition<AimShootTransition>();
            AddTransition<MovementTransition>();
            AddTransition<IdleTransition>();
        }

        private Shoot _shoot => _shootService.CurrentShoot;
        private OnShootAnimationPlayer _onShootAnimationPlayer => _shootService.OnShootAnimationPlayer;

        protected override void SetUpTransitionAvailability()
        {
            if (!_onShootAnimationPlayer.AnimationFinished())
            {
                TransitionAvailable = false;
                return;
            }

            TransitionAvailable = true;
        }

        public void Enter()
        {
            TransitionAvailable = false;
            _shootService.Aimer.StopAim();
            _heroService.HeroMovement.StopAll();
            _shoot.StartShooting();
        }

        public void Exit()
        {
            _shoot.StopShooting();
        }
    }
}