using Zenject;

namespace CodeBase.Gameplay.Shootables.States.Conditionals
{
    public class ConditionalFactory : IConditionalFactory
    {
        private readonly DiContainer _diContainer;

        public ConditionalFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Get<T>() where T : ICondition
        {
            return _diContainer.Resolve<T>();
        }
    }
}