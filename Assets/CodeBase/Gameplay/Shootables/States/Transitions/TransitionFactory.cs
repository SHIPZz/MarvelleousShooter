using Zenject;

namespace CodeBase.Gameplay.Shootables.States
{
    public interface ITransitionFactory
    {
        T Get<T>() where T : BaseShootTransition;
    }

    public class TransitionFactory : ITransitionFactory
    {
        private readonly DiContainer _diContainer;

        public TransitionFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T Get<T>() where T : BaseShootTransition
        {
            return _diContainer.Resolve<T>();
        }
    }
}