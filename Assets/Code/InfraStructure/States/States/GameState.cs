using Code.Data.Services;
using Code.ECS;
using Code.ECS.Common.Entity;
using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Systems;
using Code.Extensions;
using Code.Gameplay.AbilitySystem;
using Code.Gameplay.Cameras;
using Code.Gameplay.Enemies.Services;
using Code.Gameplay.Heroes;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.LevelDatas;
using Code.Gameplay.Shootables.Factory;
using Code.Gameplay.Shootables.Services;
using Code.InfraStructure.States.StateMachine;
using Code.SaveData;
using IUpdateable = Code.InfraStructure.States.StateInfrastructure.IUpdateable;

namespace Code.InfraStructure.States.States
{
    public class GameState : SimpleState, IUpdateable
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
        private ISystemFactory _systemFactory;
        private BattleFeature _battleFeature;

        public GameState(ILevelDataProvider levelDataProvider,
            ICameraProvider cameraProvider, 
            IAbilityService abilityService, 
            IShootService shootService,
            IHeroShootHolderService heroShootHolderService,
            IWorldDataService worldDataService,
            IShootFactory shootFactory,
            IHeroStateMachine heroStateMachine,
            ISystemFactory systemFactory,
            IHeroService heroService)
        {
            _systemFactory = systemFactory;
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

        public override void Enter()
        {
            CreateInputEntity.Empty().isInput = true;

            _battleFeature = _systemFactory.Create<BattleFeature>();
            
            _battleFeature.Initialize();

            _abilityService.Init();
            WorldData worldData = _worldDataService.Get();

            GameEntity hero = _heroService.CreateHero();
            
            InitCamera(hero.CameraHolder);
            
            _shootFactory.Create(hero.CameraHolder.GetComponent<Hero>().WeaponHolder, worldData.PlayerData.LastWeaponId);
            
            _heroStateMachine.EnterAsync<HeroInitState>();

            foreach (EnemySpawner enemySpawner in _levelDataProvider.EnemySpawners)
                enemySpawner.Spawn();
        }


        private void InitCamera(CameraHolder cameraHolder) =>
            cameraHolder
                .With(cameraHolder => _cameraProvider.WeaponCamera = cameraHolder.WeaponCamera)
                .With(cameraHolder => _cameraProvider.Camera = cameraHolder.MainCamera)
                .With(cameraHolder => _cameraProvider.ShakeCamera = cameraHolder.ShakeCamera)
                .With(cameraHolder => _cameraProvider.RecoilRotator = cameraHolder.RecoilRotator)
                .With(cameraHolder => _cameraProvider.RecoilCamera = cameraHolder.RecoilCamera)
                .With(cameraHolder => _cameraProvider.CinemachineImpulseSource = cameraHolder.CinemachineImpulseSource);

        protected override void Exit() { }
        
        public void Update()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }
    }
}
