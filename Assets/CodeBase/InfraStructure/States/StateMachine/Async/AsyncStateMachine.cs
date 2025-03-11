using CodeBase.InfraStructure.States.Factory;
using CodeBase.InfraStructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace CodeBase.InfraStructure.States.StateMachine.Async
{
    public class AsyncStateMachine : ITickable, IAsyncStateMachine
    {
        private IExitableAsyncState _activeState;
        private readonly IStateFactory _stateFactory;

        protected AsyncStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
                updateableState.Update();
        }

        public async UniTask EnterAsync<TState>() where TState : class, IAsyncState
        {
            if (_activeState != null && _activeState.GetType() == typeof(TState))
                return;

            TState state = await ChangeStateAsync<TState>();
            await state.EnterAsync();
        }

        public async UniTask EnterAsync<TState, TPayload>(TPayload payload) where TState : class, IAsyncPayloadState<TPayload>
        {
            if (_activeState != null && _activeState.GetType() == typeof(TState))
                return;

            TState state = await ChangeStateAsync<TState>();
            await state.EnterAsync(payload);
        }

        private async UniTask<TState> ChangeStateAsync<TState>() where TState : class, IExitableAsyncState
        {
            Debug.Log($"@@@{_activeState} - 1");
            if (_activeState != null)
            {
                await _activeState.ExitAsync();
            }

            TState state = _stateFactory.GetAsyncState<TState>();
            _activeState = state;
            Debug.Log($"@@@{_activeState} -2");

            return state;
        }
    }
}