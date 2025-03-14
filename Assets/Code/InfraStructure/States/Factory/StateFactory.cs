using Code.ECS.Infrastructure.StateInfrastructure;
using Code.InfraStructure.States.StateInfrastructure;
using Code.InfraStructure.States.StateMachine.Async;
using Zenject;

namespace Code.InfraStructure.States.Factory
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer _container;

        public StateFactory(DiContainer container)
        {
            _container = container;
        }

        public T GetState<T>() where T : class, IExitableState
        {
            return _container.Resolve<T>();
        }

        public T GetPromiseState<T>() where T : class, IPromiseExitableState
        {
            return _container.Resolve<T>();
        }

        public T GetAsyncState<T>() where T : class, IExitableAsyncState
        {
            return _container.Resolve<T>();
        }
    }
}