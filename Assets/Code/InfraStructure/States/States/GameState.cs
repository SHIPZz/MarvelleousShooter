using System;
using Code.Data.Services;
using Code.ECS;
using Code.ECS.Common.Entity;
using Code.ECS.Gameplay.Features.Cameras.Factories;
using Code.ECS.Gameplay.Features.Cooldown;
using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Systems;
using Code.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.Enemies.Services;
using Code.Gameplay.Heroes;
using Code.Gameplay.Heroes.Factory;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.LevelDatas;
using Code.Gameplay.Shootables;
using Code.Gameplay.Shootables.Factory;
using Code.Gameplay.Shootables.Recoils;
using Code.SaveData;
using Cysharp.Threading.Tasks;
using UnityEngine;
using IUpdateable = Code.InfraStructure.States.StateInfrastructure.IUpdateable;

namespace Code.InfraStructure.States.States
{
    public class GameState : SimpleState, IUpdateable, IDisposable
    {
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly ICameraProvider _cameraProvider;
        private readonly IHeroFactory _heroFactory;
        private readonly IShootFactory _shootFactory;
        private readonly IWorldDataService _worldDataService;
        private readonly ISystemFactory _systemFactory;
        private readonly IHeroRepository _heroRepository;
        private readonly ICameraFactory _cameraFactory;
        
        private BattleFeature _battleFeature;

        public GameState(ILevelDataProvider levelDataProvider,
            ICameraProvider cameraProvider, 
            IWorldDataService worldDataService,
            IShootFactory shootFactory,
            ISystemFactory systemFactory,
            ICameraFactory cameraFactory,
            IHeroRepository heroRepository, 
            IHeroFactory heroFactory)
        {
            _cameraFactory = cameraFactory;
            _heroRepository = heroRepository;
            _heroFactory = heroFactory;
            _systemFactory = systemFactory;
            _worldDataService = worldDataService;
            _shootFactory = shootFactory;
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
        }

        public override void Enter()
        {
            CreateInputEntity.Empty()
                .With(x => x.AddMouseAxis(Vector2.zero))
                .isInput = true;

            CreateEntity.Empty()
                .With(x => x.isShootSwitchingReady = true)
                .With(x => x.isShootSwitchingAvailable = true)
                .With(x => x.isConnectedWithHero = true)
                .With(x => x.isActive = true)
                .With(x => x.PutOnCooldown(0f))
                .With(x => x.isSwitchable = true);

            _battleFeature = _systemFactory.Create<BattleFeature>();
            
            _battleFeature.Initialize();

            WorldData worldData = _worldDataService.Get();

            GameEntity hero = _heroFactory.Create(_levelDataProvider.StartPoint,_levelDataProvider.StartPoint.position,Quaternion.identity);
            
            InitCamera(hero.CameraHolder);

            Transform weaponHolder = hero.CameraHolder.GetComponent<Hero>().WeaponHolder;
            
            GameEntity mainGun =_shootFactory
                .Create(weaponHolder, worldData.PlayerData.LastWeaponId, hero.Id)
                .With(x => x.isHeroGun = true)
                .With(x => x.isShootCooldownUp = true)
                .With(x => x.isActive = true)
                ;
            
            GameEntity knife =_shootFactory
                    .Create(weaponHolder, ShootTypeId.Knife, hero.Id)
                    .With(x => x.isHeroGun = true)
                    .With(x => x.isViewActive = false)
                ;
            
            hero.AddAnimancerAnimator(mainGun.AnimancerAnimator);
            hero.AddCurrentGunId(mainGun.Id);
            
            _heroRepository.SetCurrentGun(mainGun);
            
            
            foreach (EnemySpawner enemySpawner in _levelDataProvider.EnemySpawners)
                enemySpawner.Spawn();
        }


        private void InitCamera(CameraHolder cameraHolder)
        {
            _cameraFactory.CreateEntity(cameraHolder.MainCamera);
            
            cameraHolder
                .With(cameraHolder => _cameraProvider.WeaponCamera = cameraHolder.WeaponCamera)
                .With(cameraHolder => _cameraProvider.Camera = cameraHolder.MainCamera)
                .With(cameraHolder => _cameraProvider.ShakeCamera = cameraHolder.ShakeCamera)
                .With(cameraHolder => _cameraProvider.RecoilRotator = cameraHolder.RecoilRotator)
                .With(cameraHolder => _cameraProvider.RecoilCamera = cameraHolder.RecoilCamera)
                .With(cameraHolder => _cameraProvider.CinemachineImpulseSource = cameraHolder.CinemachineImpulseSource);
        }

        protected override void Exit()
        {
            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature.ClearReactiveSystems();
        }
        
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
            _battleFeature.ClearReactiveSystems();
        }
    }
}
