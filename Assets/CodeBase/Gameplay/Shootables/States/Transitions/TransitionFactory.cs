using Zenject;

namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public interface ITransitionFactory
    {
        T Get<T>() where T : class, ITransition;
    }

    public class TransitionFactory : ITransitionFactory
    {
        private readonly DiContainer _diContainer;

        public TransitionFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T Get<T>() where T : class, ITransition
        {
            return _diContainer.Resolve<T>();
        }
    }
}