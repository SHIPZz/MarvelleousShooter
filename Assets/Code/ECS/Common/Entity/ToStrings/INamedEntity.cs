using Entitas;

namespace Code.ECS.Common.Entity.ToStrings
{
  public interface INamedEntity : IEntity
  {
    string EntityName(IComponent[] components);
    string BaseToString();
  }
}