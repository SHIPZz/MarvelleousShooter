using System.Collections.Generic;
using CodeBase.InfraStructure.States.StateInfrastructure;
using Zenject;

namespace CodeBase.Gameplay.Common
{
    public class UpdateService : ITickable, IUpdateService
    {
        private readonly List<IUpdateable> _updatables = new();

        public void Add(IUpdateable updatable) => _updatables.Add(updatable);

        public void Tick()
        {
            foreach (IUpdateable updatable in _updatables)
            {
                updatable.Update();
            }
        }
    }
}