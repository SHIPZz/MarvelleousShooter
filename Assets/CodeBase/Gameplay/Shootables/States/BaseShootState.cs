using System.Collections.Generic;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Transitions;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.States
{
    public abstract class BaseShootState : IUpdateable, IInitializable
    {
        protected readonly IInputService _inputService;
        protected readonly IShootService _shootService;
        protected readonly IShootStateMachine _shootStateMachine;
        protected readonly IHeroService _heroService;
        protected readonly ITransitionFactory _transitionFactory;

        private readonly List<ITransition> _transitions = new();

        protected virtual bool TransitionAvailable { get; set; } = true;
        
        protected BaseShootState(IInputService inputService,
            IShootService shootService,
            IShootStateMachine shootStateMachine,
            IHeroService heroService, 
            ITransitionFactory transitionFactory)
        {
            _inputService = inputService;
            _shootService = shootService;
            _shootStateMachine = shootStateMachine;
            _heroService = heroService;
            _transitionFactory = transitionFactory;
        }

        public void Initialize()
        {
            _transitions.Add(_transitionFactory.Get<ReloadTransition>());
        }

        public void Update()
        {
            foreach (ITransition transition in _transitions)
            {
                if (transition.ShouldTransition() && TransitionAvailable)
                {
                    transition.MoveToTargetState();
                    return;
                }
            }

            OnUpdate();
            SetUpTransitionAvailability();
        }

        protected virtual void OnUpdate() { }

        protected virtual void SetUpTransitionAvailability()
        {
            
        }

        protected void AddTransition<T>() where T : class, ITransition
        {
            ITransition transition = _transitionFactory.Get<T>();

            if (!_transitions.Contains(transition))
                _transitions.Add(transition);
        }
    }
}