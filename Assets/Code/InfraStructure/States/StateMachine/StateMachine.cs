using Code.InfraStructure.States.Factory;
using Code.InfraStructure.States.StateInfrastructure;
using UnityEngine;
using Zenject;

namespace Code.InfraStructure.States.StateMachine
{
    public class StateMachine : ITickable
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;

        protected StateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }

        public void Enter<TState>() where TState : class, IState
        {
            if (_activeState != null && _activeState.GetType() == typeof(TState))
                return;

            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            if (_activeState != null && _activeState.GetType() == typeof(TState))
                return;

            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            Debug.Log($"@@@: exit state - {_activeState}");
            _activeState?.Exit();

            TState state = _stateFactory.GetState<TState>();
            _activeState = state;
            Debug.Log($"@@@: active state - {_activeState}");

            return state;
        }
    }
}