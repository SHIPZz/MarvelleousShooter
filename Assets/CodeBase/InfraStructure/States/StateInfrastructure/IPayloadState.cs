namespace CodeBase.InfraStructure.States.StateInfrastructure
{
  public interface IPayloadState<TPayload> : IExitableState
  {
    void Enter(TPayload targetGun);
  }
}