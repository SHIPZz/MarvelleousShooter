using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.States
{
    public sealed class MovementState : BaseShootState, IState
    {
        public MovementState(IInputService inputService, IShootService shootService,
            IShootStateMachine shootStateMachine, IHeroService heroService,
            ITransitionFactory transitionFactory) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory)
        {
            AddTransition<IdleTransition>();
            AddTransition<AimMovementTransition>();
            AddTransition<IdleFocusTransition>();
            AddTransition<ShootTransition>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            AnimateWalking();
            AnimateRunning();
        }

        private void AnimateWalking()
        {
            if (!_inputService.IsRunningPressed())
                _heroService.HeroMovement.Walk();
        }

        private void AnimateRunning()
        {
            Debug.Log($"run");
            if (_inputService.IsRunningPressed())
                _heroService.HeroMovement.Run();
        }

        public void Exit()
        {
            
        }
        
        public void Enter()
        {
            AnimateWalking();
            AnimateRunning();
        }
    }
}