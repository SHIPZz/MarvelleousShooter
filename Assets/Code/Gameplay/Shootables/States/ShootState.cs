using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Shootables.States
{
    public class ShootState : BaseShootState, IState
    {
        private readonly IGroup<GameEntity> _shootables;

        public ShootState(IInputService inputService, IShootService shootService, IShootStateMachine shootStateMachine,
            IHeroService heroService, ITransitionFactory transitionFactory, GameContext gameContext,
            InputContext inputContext) : base(inputService, shootService, shootStateMachine, heroService,
            transitionFactory, gameContext, inputContext)
        {
           _shootables = gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable));
            
            AddTransition<AimShootTransition>();
            AddTransition<MovementTransition>();
            AddTransition<IdleTransition>();
        }

        protected override void SetUpTransitionAvailability()
        {
            foreach (GameEntity shootable in _shootables)
            {
                if (!shootable.isShootAnimationFinished)
                {
                    TransitionAvailable = false;
                    return;
                }
            }

            TransitionAvailable = true;
        }

        public void Enter()
        {
            TransitionAvailable = false;

            foreach (GameEntity shootable in _shootables)
            {
                shootable.isShootingAvailable = true;
            }
        }

        public void Exit()
        {
            foreach (GameEntity shootable in _shootables)
            {
                // shootable.isShootingAvailable = false;
            }
        }
    }
}