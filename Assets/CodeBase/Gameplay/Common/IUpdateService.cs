using CodeBase.InfraStructure.States.StateInfrastructure;

namespace CodeBase.Gameplay.Common
{
    public interface IUpdateService
    {
        void Add(IUpdateable updatable);
    }
}