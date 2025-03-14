using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Timer;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.States.Transitions.Conditionals;
using Code.InfraStructure.States.StateMachine;
using UniRx;
using Zenject;

namespace Code.Gameplay.Shootables.States.Transitions
{
    public abstract class BaseShootTransition : IInitializable, IDisposable
    {
        protected CompositeDisposable CompositeDisposable = new();

        private readonly List<ICondition> _conditions = new();

        [Inject] protected IShootService ShootService;
        [Inject] protected IInputService InputService;
        [Inject] protected IHeroService HeroService;
        [Inject] protected ITimerService TimerService;
        [Inject] protected IShootStateMachine ShootStateMachine;
        [Inject] protected IConditionalFactory ConditionalFactory;
        [Inject] protected GameContext Game;
        [Inject] protected InputContext Input;

        public virtual void Initialize()
        {
            OnInitialize();
            OnAddCondition();
        }

        protected bool ConditionMet<T>() where T : ICondition => ConditionalFactory.Get<T>().IsMet();

        protected virtual void OnAddCondition() => AddConditional<NeedReloadingCondition>(true);

        protected virtual void OnInitialize()
        {
        
        }

        protected T GetCondition<T>() where T : ICondition => ConditionalFactory.Get<T>();

        protected InvertedCondition GetInvertedCondition<T>() where T : ICondition => new InvertedCondition(ConditionalFactory.Get<T>());

        protected void AddConditional<T>(bool isInverted = false) where T : ICondition
        {
            ICondition targetCondition = ConditionalFactory.Get<T>();

            if (_conditions.Contains(targetCondition))
                return;

            if (isInverted)
                targetCondition = new InvertedCondition(targetCondition);

            _conditions.Add(targetCondition);
        }

        public abstract void MoveToTargetState();

        public virtual bool ShouldTransition() => _conditions.All(x => x.IsMet());

        public virtual void Dispose() => CompositeDisposable?.Dispose();
    }
}