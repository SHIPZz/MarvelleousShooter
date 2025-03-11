namespace CodeBase.InfraStructure.States.StateInfrastructure
{
  public interface IState: IExitableState
  {
    void Enter();
  }
}