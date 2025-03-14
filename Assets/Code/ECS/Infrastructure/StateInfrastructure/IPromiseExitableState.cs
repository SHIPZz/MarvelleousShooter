using RSG;

namespace Code.ECS.Infrastructure.StateInfrastructure
{
  public interface IPromiseExitableState
  {
    IPromise BeginExit();
    void EndExit();
  }
}