using Zenject;

namespace Code.Gameplay.Shootables.States.Transitions.Conditionals
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