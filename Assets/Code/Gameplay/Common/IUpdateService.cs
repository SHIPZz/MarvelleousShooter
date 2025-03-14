using Code.InfraStructure.States.StateInfrastructure;

namespace Code.Gameplay.Common
{
    public interface IUpdateService
    {
        void Add(IUpdateable updatable);
    }
}