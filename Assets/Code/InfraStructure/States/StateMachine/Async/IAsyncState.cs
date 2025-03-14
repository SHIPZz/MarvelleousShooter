using Cysharp.Threading.Tasks;

namespace Code.InfraStructure.States.StateMachine.Async
{
    public interface IAsyncState : IExitableAsyncState
    {
        UniTask EnterAsync();
    }
}