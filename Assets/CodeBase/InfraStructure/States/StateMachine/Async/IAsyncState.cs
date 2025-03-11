using Cysharp.Threading.Tasks;

namespace CodeBase.InfraStructure.States.StateMachine.Async
{
    public interface IAsyncState : IExitableAsyncState
    {
        UniTask EnterAsync();
    }
}