
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine.Async;

namespace Code.InfraStructure.States.Factory
{
  public interface IStateFactory
  {
    T GetState<T>() where T : class, IExitableState;
    
    T GetPromiseState<T>() where T : class, ECS.Infrastructure.StateInfrastructure.IPromiseExitableState;
    
    T GetAsyncState<T>() where T : class, IExitableAsyncState;
  }
}