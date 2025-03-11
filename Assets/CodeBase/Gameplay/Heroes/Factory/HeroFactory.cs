using CodeBase.Data.Services;
using CodeBase.Extensions;
using CodeBase.Gameplay.Heroes.Configs;
using CodeBase.Gameplay.Shootables;
using CodeBase.Gameplay.Shootables.Factory;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.Visuals;
using CodeBase.SaveData;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Heroes.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly HeroConfig _heroConfig;
        private readonly IInstantiator _instantiator;
        private readonly IWorldDataService _worldDataService;

        public HeroFactory(HeroConfig heroConfig, 
            IInstantiator instantiator,
            IWorldDataService worldDataService
            )
        {
            _worldDataService = worldDataService;
            _instantiator = instantiator;
            _heroConfig = heroConfig;
        }

        public Hero Create(Transform parent, Vector3 at, Quaternion rotation)
        {
            WorldData worldData = _worldDataService.Get();
            
            Hero prefab = _heroConfig.Prefab;

            Hero hero = _instantiator.InstantiatePrefabForComponent<Hero>(prefab, at, rotation, parent);

            return hero;
        }
    }
}