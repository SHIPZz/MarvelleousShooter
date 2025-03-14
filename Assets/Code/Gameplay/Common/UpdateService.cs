using System.Collections.Generic;
using Code.InfraStructure.States.StateInfrastructure;
using Zenject;

namespace Code.Gameplay.Common
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