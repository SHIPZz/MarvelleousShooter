using Entitas;

namespace Code.ECS.Entity.ToStrings
{
  public interface INamedEntity : IEntity
  {
    string EntityName(IComponent[] components);
    string BaseToString();
  }
}