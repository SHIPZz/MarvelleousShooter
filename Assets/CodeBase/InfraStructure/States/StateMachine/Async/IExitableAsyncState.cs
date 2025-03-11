using System.Threading;
using Cysharp.Threading.Tasks;

namespace CodeBase.InfraStructure.States.StateMachine.Async
{
    public interface IExitableAsyncState
    {
        UniTask ExitAsync();
    }
}