namespace Code.ECS.Infrastructure.StateInfrastructure
{
  public interface IPayloadState<TPayload> : IPromiseExitableState
  {
    void Enter(TPayload payload);
  }
}