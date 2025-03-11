using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.InfraStructure.States.StateMachine.Async;

namespace CodeBase.InfraStructure.States.Factory
{
  public interface IStateFactory
  {
    T GetState<T>() where T : class, IExitableState;
    
    T GetAsyncState<T>() where T : class, IExitableAsyncState;
  }
}