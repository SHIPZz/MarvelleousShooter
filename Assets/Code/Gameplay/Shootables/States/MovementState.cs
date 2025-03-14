using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using UnityEngine;

namespace Code.Gameplay.Shootables.States
{
    public sealed class MovementState : BaseShootState, IState
    {
        public MovementState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
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
            // if (!_inputService.IsRunningPressed())
            //     _heroService.HeroMovement.Walk();
        }

        private void AnimateRunning()
        {
            Debug.Log($"run");
            // if (_inputService.IsRunningPressed())
                // _heroService.HeroMovement.Run();
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