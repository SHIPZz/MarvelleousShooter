using CodeBase.Extensions;
using CodeBase.Gameplay.AbilitySystem;
using CodeBase.Gameplay.AbilitySystem.StatSystem;
using CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Heroes.Factory;
using CodeBase.Gameplay.LevelDatas;
using ECM.Components;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.Services
{
    public class HeroService : IHeroService
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IHeroFactory _heroFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IAbilityService _abilityService;
        private readonly IStatService _statService;

        private Hero _createdHero;
        private HeroMovement _heroMovement;
        private CharacterMovement _characterMovement;

        public Hero Hero => _createdHero;

        public HeroMovement HeroMovement => _heroMovement;

        public bool IsOnGround => _characterMovement.isOnGround;

        public HeroService(ILevelDataProvider levelDataProvider,
            IHeroFactory heroFactory,
            ICameraProvider cameraProvider,
            IAbilityService abilityService,
            IStatService statService
        )
        {
            _statService = statService;
            _abilityService = abilityService;
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
            _heroFactory = heroFactory;
        }

        public Hero CreateHero()
        {
            return _heroFactory
                    .Create(null, _levelDataProvider.StartPoint.position, Quaternion.identity)
                    .With(hero => _abilityService.AddAbilityOwner(hero.GetComponent<AbilityOwner>()))
                    .With(hero => _statService.Add(hero.GetComponent<Stats>()))
                    .With(hero => _createdHero = hero)
                    .With(hero => _heroMovement = hero.GetComponent<HeroMovement>())
                    .With(hero => _characterMovement = hero.GetComponent<CharacterMovement>())
                    .With(hero => _cameraProvider.Camera = hero.GetComponentInChildren<Camera>())
                ;
        }
    }
}