using Code.ECS.Infrastructure.StateInfrastructure;

namespace Code.ECS.Infrastructure.StateMachine
{
  public interface IGameStateMachine 
  {
    void Enter<TState>() where TState : class, IState;
    void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
  }
}