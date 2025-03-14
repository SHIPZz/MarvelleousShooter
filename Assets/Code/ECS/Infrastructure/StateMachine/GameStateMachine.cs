using Code.ECS.Infrastructure.StateInfrastructure;
using Code.InfraStructure.States.Factory;
using RSG;
using UnityEngine;
using Zenject;
using IUpdateable = Code.InfraStructure.States.StateInfrastructure.IUpdateable;

namespace Code.ECS.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine, ITickable
    {
        private IPromiseExitableState _activeState;
        private readonly IStateFactory _stateFactory;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }

        public void Enter<TState>() where TState : class, IState =>
            RequestEnter<TState>()
                .Done();

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload> =>
            RequestEnter<TState, TPayload>(payload)
                .Done();

        private IPromise<TState> RequestEnter<TState>() where TState : class, IState =>
            RequestChangeState<TState>()
                .Then(EnterState);

        private IPromise<TState> RequestEnter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload> =>
            RequestChangeState<TState>()
                .Then(state => EnterPayloadState(state, payload));

        private TState EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);
            return state;
        }

        private TState EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            state.Enter();
            return state;
        }

        private IPromise<TState> RequestChangeState<TState>() where TState : class, IPromiseExitableState
        {
            if (_activeState != null)
            {
              return  _activeState.BeginExit()
                    .Then(_activeState.EndExit)
                    .Then(ChangeState<TState>)
                    ;
            }

            return ChangeState<TState>();
        }

        private IPromise<TState> ChangeState<TState>() where TState : class, IPromiseExitableState
        {
            TState state = _stateFactory.GetPromiseState<TState>();

            return Promise<TState>.Resolved(state);
        }
    }
}