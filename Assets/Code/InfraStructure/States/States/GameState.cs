using System;
using Code.Data.Services;
using Code.ECS;
using Code.ECS.Common.Entity;
using Code.ECS.Gameplay.Features.Cooldown;
using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Systems;
using Code.Extensions;
using Code.Gameplay.AbilitySystem;
using Code.Gameplay.Cameras;
using Code.Gameplay.Enemies.Services;
using Code.Gameplay.Heroes;
using Code.Gameplay.Heroes.Factory;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.LevelDatas;
using Code.Gameplay.Shootables;
using Code.Gameplay.Shootables.Factory;
using Code.Gameplay.Shootables.Services;
using Code.InfraStructure.States.StateMachine;
using Code.SaveData;
using UnityEngine;
using IUpdateable = Code.InfraStructure.States.StateInfrastructure.IUpdateable;

namespace Code.InfraStructure.States.States
{
    public class GameState : SimpleState, IUpdateable, IDisposable
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IAbilityService _abilityService;
        private readonly IHeroFactory _heroFactory;
        private readonly IShootFactory _shootFactory;
        private readonly IWorldDataService _worldDataService;
        private readonly ISystemFactory _systemFactory;
        private readonly IHeroRepository _heroRepository;
        
        private BattleFeature _battleFeature;

        public GameState(ILevelDataProvider levelDataProvider,
            ICameraProvider cameraProvider, 
            IAbilityService abilityService, 
            IWorldDataService worldDataService,
            IShootFactory shootFactory,
            ISystemFactory systemFactory,
            IHeroRepository heroRepository, 
            IHeroFactory heroFactory)
        {
            _heroRepository = heroRepository;
            _heroFactory = heroFactory;
            _systemFactory = systemFactory;
            _worldDataService = worldDataService;
            _shootFactory = shootFactory;
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
            _abilityService = abilityService;
        }

        public override void Enter()
        {
            CreateInputEntity.Empty().isInput = true;

            CreateEntity.Empty()
                .With(x => x.isShootSwitchingReady = true)
                .With(x => x.isShootSwitchingAvailable = true)
                .With(x => x.isConnectedWithHero = true)
                .With(x => x.isActive = true)
                .With(x => x.PutOnCooldown(0f))
                .With(x => x.isSwitchable = true);

            _battleFeature = _systemFactory.Create<BattleFeature>();
            
            _battleFeature.Initialize();

            _abilityService.Init();
            WorldData worldData = _worldDataService.Get();

            GameEntity hero = _heroFactory.Create(null,_levelDataProvider.StartPoint.position,Quaternion.identity);
            
            InitCamera(hero.CameraHolder);

            Transform weaponHolder = hero.CameraHolder.GetComponent<Hero>().WeaponHolder;
            
            GameEntity shoot =_shootFactory
                .Create(weaponHolder, worldData.PlayerData.LastWeaponId, hero.Id)
                .With(x => x.isHeroGun = true)
                .With(x => x.isActive = true)
                ;
            
            GameEntity knife =_shootFactory
                    .Create(weaponHolder, ShootTypeId.Knife, hero.Id)
                    .With(x => x.isHeroGun = true)
                    .With(x => x.isViewActive = false)
                ;
            
            hero.AddAnimancerAnimator(shoot.AnimancerAnimator);
            hero.AddCurrentGunId(shoot.Id);
            
            _heroRepository.SetCurrentGun(shoot);
            
            
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
            if(_battleFeature ==null)
                return;
            
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        public void Dispose()
        {
            _battleFeature.TearDown();
        }
    }
}
