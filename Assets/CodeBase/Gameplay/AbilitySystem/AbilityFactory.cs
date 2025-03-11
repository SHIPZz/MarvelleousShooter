using Zenject;

namespace CodeBase.Gameplay.AbilitySystem
{
    public interface IAbilityFactory
    {
        T CreateAbility<T>() where T : AbstractAbility;
    }

    public class AbilityFactory : IAbilityFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAbilityStaticDataService _abilityStaticDataService;

        public AbilityFactory(IInstantiator instantiator, IAbilityStaticDataService abilityStaticDataService)
        {
            _instantiator = instantiator;
            _abilityStaticDataService = abilityStaticDataService;
        }

        public T CreateAbility<T>() where T : AbstractAbility
        {
            return _instantiator.Instantiate<T>();
        }
    }
}