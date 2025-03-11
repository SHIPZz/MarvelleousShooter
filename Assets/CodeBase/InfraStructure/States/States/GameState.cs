using CodeBase.Data.Services;
using CodeBase.Extensions;
using CodeBase.Gameplay.AbilitySystem;
using CodeBase.Gameplay.Cameras;
using CodeBase.Gameplay.Enemies.Services;
using CodeBase.Gameplay.Heroes;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.LevelDatas;
using CodeBase.Gameplay.Shootables;
using CodeBase.Gameplay.Shootables.Factory;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateInfrastructure;
using CodeBase.InfraStructure.States.StateMachine;
using CodeBase.SaveData;
using UnityEngine;

namespace CodeBase.InfraStructure.States.States
{
    public class GameState : IState
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IAbilityService _abilityService;
        private readonly IHeroService _heroService;
        private readonly IShootFactory _shootFactory;
        private readonly IWorldDataService _worldDataService;
        private readonly IShootService _shootService;
        private readonly IHeroShootHolderService _heroShootHolderService;
        private IHeroStateMachine _heroStateMachine;

        public GameState(ILevelDataProvider levelDataProvider,
            ICameraProvider cameraProvider, 
            IAbilityService abilityService, 
            IShootService shootService,
            IHeroShootHolderService heroShootHolderService,
            IWorldDataService worldDataService,
            IShootFactory shootFactory,
            IHeroStateMachine heroStateMachine,
            IHeroService heroService)
        {
            _heroStateMachine = heroStateMachine;
            _heroShootHolderService = heroShootHolderService;
            _shootService = shootService;
            _worldDataService = worldDataService;
            _shootFactory = shootFactory;
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
            _abilityService = abilityService;
            _heroService = heroService;
        }

        public void Enter()
        {
            _abilityService.Init();
            WorldData worldData = _worldDataService.Get();

            Hero hero = _heroService.CreateHero();
            InitCamera(hero);
            InitWeapon(hero, worldData);

            _heroStateMachine.EnterAsync<HeroInitState>();

            _abilityService.Start<TemporaryIncreaseDamageAbility>();
            _abilityService.Start<PoisonDamageAbility>();
            _abilityService.Start<PiercingAbility>();

            foreach (EnemySpawner enemySpawner in _levelDataProvider.EnemySpawners)
                enemySpawner.Spawn();
        }

        private void InitWeapon(Hero hero, WorldData worldData)
        {
            Shoot shoot = _shootFactory.Create(hero.WeaponHolder, worldData.PlayerData.LastWeaponId);
            var knife = _shootFactory.Create(hero.WeaponHolder, ShootTypeId.Knife)
                .With(x => x.gameObject.SetActive(false));

            _shootService.SetCurrentShoot(shoot);
            _heroShootHolderService.Add(shoot);
            _heroShootHolderService.Add(knife);
        }

        private void InitCamera(Hero hero)
        {
            hero
                .GetComponent<CameraHolder>()
                .With(cameraHolder => _cameraProvider.WeaponCamera = cameraHolder.WeaponCamera)
                .With(cameraHolder => _cameraProvider.Camera = cameraHolder.MainCamera)
                .With(cameraHolder => _cameraProvider.ShakeCamera = cameraHolder.ShakeCamera)
                .With(cameraHolder => _cameraProvider.RecoilRotator = cameraHolder.RecoilRotator)
                .With(cameraHolder => _cameraProvider.RecoilCamera = cameraHolder.RecoilCamera)
                .With(cameraHolder => _cameraProvider.CinemachineImpulseSource = cameraHolder.CinemachineImpulseSource)
                ;
        }

        public void Exit() { }
    }
}
