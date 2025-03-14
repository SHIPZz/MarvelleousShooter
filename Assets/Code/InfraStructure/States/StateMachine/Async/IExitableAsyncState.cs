using Cysharp.Threading.Tasks;

namespace Code.InfraStructure.States.StateMachine.Async
{
    public interface IExitableAsyncState
    {
        UniTask ExitAsync();
    }
}