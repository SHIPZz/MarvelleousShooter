using Entitas;

namespace Code.ECS.Systems
{
  public interface ISystemFactory
  {
    T Create<T>() where T : ISystem;
    T Create<T>(params object[] args) where T : ISystem;
  }
}