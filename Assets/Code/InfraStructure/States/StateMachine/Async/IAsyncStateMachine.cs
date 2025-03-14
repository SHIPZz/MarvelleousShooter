using Cysharp.Threading.Tasks;

namespace Code.InfraStructure.States.StateMachine.Async
{
    public interface IAsyncStateMachine
    {
        UniTask EnterAsync<TState>() where TState : class, IAsyncState;
        UniTask EnterAsync<TState, TPayload>(TPayload payload) where TState : class, IAsyncPayloadState<TPayload>;
    }
}