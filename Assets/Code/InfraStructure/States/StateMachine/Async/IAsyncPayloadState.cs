using Cysharp.Threading.Tasks;

namespace Code.InfraStructure.States.StateMachine.Async
{
    public interface IAsyncPayloadState<TPayload> : IExitableAsyncState
    {
        UniTask EnterAsync(TPayload targetGun);
    }
}