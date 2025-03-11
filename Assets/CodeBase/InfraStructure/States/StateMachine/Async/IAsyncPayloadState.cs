using System.Threading;
using Cysharp.Threading.Tasks;

namespace CodeBase.InfraStructure.States.StateMachine.Async
{
    public interface IAsyncPayloadState<TPayload> : IExitableAsyncState
    {
        UniTask EnterAsync(TPayload targetGun);
    }
}