namespace Code.ECS.Infrastructure.StateInfrastructure
{
  public interface IState: IPromiseExitableState
  {
    void Enter();
  }
}