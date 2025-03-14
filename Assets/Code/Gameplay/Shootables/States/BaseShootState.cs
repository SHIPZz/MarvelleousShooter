using System.Collections.Generic;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.States
{
    public abstract class BaseShootState : IUpdateable, IInitializable
    {
        protected readonly IInputService _inputService;
        protected readonly IShootService _shootService;
        protected readonly IShootStateMachine _shootStateMachine;
        protected readonly IHeroService _heroService;
        protected readonly ITransitionFactory _transitionFactory;
        protected readonly GameContext GameContext;
        protected readonly InputContext InputContext;

        private readonly List<BaseShootTransition> _transitions = new();

        protected virtual bool TransitionAvailable { get; set; } = true;

        protected BaseShootState(IInputService inputService,
            IShootService shootService,
            IShootStateMachine shootStateMachine,
            IHeroService heroService,
            ITransitionFactory transitionFactory, GameContext gameContext, InputContext inputContext)
        {
            _inputService = inputService;
            _shootService = shootService;
            _shootStateMachine = shootStateMachine;
            _heroService = heroService;
            _transitionFactory = transitionFactory;
            GameContext = gameContext;
            InputContext = inputContext;
        }

        public void Initialize()
        {
            AddImportantTransitions();
        }

        public void Update()
        {
            OnUpdate();
            SetUpTransitionAvailability();

            foreach (BaseShootTransition transition in _transitions)
            {
                if (transition.ShouldTransition() && TransitionAvailable)
                {
                    Debug.Log($"{transition.GetType()} - move to state");
                    transition.MoveToTargetState();
                    return;
                }
            }
        }

        protected virtual void OnUpdate() { }

        protected virtual void SetUpTransitionAvailability() { }

        protected void AddTransition<T>() where T : BaseShootTransition
        {
            var transition = _transitionFactory.Get<T>();

            if (!_transitions.Contains(transition))
                _transitions.Add(transition);
        }

        private void AddImportantTransitions()
        {
            _transitions.Add(_transitionFactory.Get<ReloadTransition>());
        }
    }
}