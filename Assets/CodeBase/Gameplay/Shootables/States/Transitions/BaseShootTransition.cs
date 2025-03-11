using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Common.Timer;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.States.Conditionals;
using CodeBase.InfraStructure.States.StateMachine;
using UniRx;
using Zenject;

public abstract class BaseShootTransition : IInitializable, IDisposable
{
    protected CompositeDisposable CompositeDisposable = new();

    private readonly List<ICondition> _conditions = new();
    private readonly List<ICondition> _orConditions = new();

    [Inject] protected IShootService ShootService;
    [Inject] protected IInputService InputService;
    [Inject] protected IHeroService HeroService;
    [Inject] protected ITimerService TimerService;
    [Inject] protected IShootStateMachine ShootStateMachine;
    [Inject] protected IConditionalFactory ConditionalFactory;

    public virtual void Initialize()
    {
        OnAddCondition();
        OnAddOrCondition();
    }

    protected bool ConditionMet<T>() where T : ICondition => ConditionalFactory.Get<T>().IsMet();

    protected virtual void OnAddCondition()
    {
        AddConditional<NeedReloadingCondition>(true);
    }
    
    protected virtual void OnAddOrCondition()
    {
        
    }

    protected T GetCondition<T>() where T : ICondition => ConditionalFactory.Get<T>();
    
    protected void AddOrConditional<T>(bool isInverted = false) where T : ICondition
    {
        ICondition targetCondition = ConditionalFactory.Get<T>();

        if (_orConditions.Contains(targetCondition))
            return;

        if (isInverted)
            targetCondition = new InvertedCondition(targetCondition);

        _orConditions.Add(targetCondition);
    }

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

    public virtual bool ShouldTransition() => _conditions.All(x => x.IsMet()) || (_orConditions.Count > 0 && _orConditions.All(x => x.IsMet()));

    public virtual void Dispose() => CompositeDisposable?.Dispose();
}