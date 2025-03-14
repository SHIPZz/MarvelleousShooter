using System.Collections.Generic;
using Code.Extensions;
using Code.Gameplay.AbilitySystem;
using Code.Gameplay.AbilitySystem.StatSystem;
using Code.Gameplay.AbilitySystem.StatSystem.StatModifiers;
using Code.Gameplay.Cameras;
using Code.Gameplay.Heroes.Factory;
using Code.Gameplay.LevelDatas;
using ECM.Components;
using UnityEngine;

namespace Code.Gameplay.Heroes.Services
{
    public class HeroService : IHeroService
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHeroFactory _heroFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IAbilityService _abilityService;
        private readonly IStatService _statService;
        private readonly IHeroRepository _heroRepository;

        private Dictionary<HeroTypeId, Hero> _heroes = new();


        public HeroService(ILevelDataProvider levelDataProvider,
            IHeroFactory heroFactory,
            ICameraProvider cameraProvider,
            IHeroRepository heroRepository,
            IAbilityService abilityService,
            IStatService statService
        )
        {
            _heroRepository = heroRepository;
            _statService = statService;
            _abilityService = abilityService;
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
            _heroFactory = heroFactory;
        }

        public GameEntity LoadHero() => _heroRepository.Load();

        public GameEntity CreateHero()
        {
            return _heroFactory.Create(null, _levelDataProvider.StartPoint.position, Quaternion.identity);
        }
    }
}