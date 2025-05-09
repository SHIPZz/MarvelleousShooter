using System;
using Code.Data.Services;
using Code.ECS;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Code.ECS.Gameplay.Features.Cameras.Factories;
using Code.ECS.Gameplay.Features.Cooldown;
using Code.ECS.Gameplay.Features.Heroes;
using Code.ECS.Gameplay.Features.Heroes.Factory;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Code.ECS.Gameplay.Features.Shoots.Factory;
using Code.ECS.Infrastructure.StateInfrastructure;
using Code.ECS.Systems;
using Code.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.LevelDatas;
using Code.SaveData;
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
        private readonly ICameraFactory _cameraFactory;
        private readonly GameContext _game;
        private readonly IIdentifierService _identifierService;

        private BattleFeature _battleFeature;

        public GameState(ILevelDataProvider levelDataProvider,
            ICameraProvider cameraProvider,
            IWorldDataService worldDataService,
            IShootFactory shootFactory,
            ISystemFactory systemFactory,
            ICameraFactory cameraFactory,
            IHeroFactory heroFactory, 
            GameContext game, 
            IIdentifierService identifierService)
        {
            _cameraFactory = cameraFactory;
            _heroFactory = heroFactory;
            _game = game;
            _identifierService = identifierService;
            _systemFactory = systemFactory;
            _worldDataService = worldDataService;
            _shootFactory = shootFactory;
            _levelDataProvider = levelDataProvider;
            _cameraProvider = cameraProvider;
        }

        public override void Enter()
        {
            CreateBattleFeature();
            
            Cursor.lockState = CursorLockMode.Locked;

            CreateInput();

            CreateShootSwitching();
            
            WorldData worldData = _worldDataService.Get();

            GameEntity hero = CreateHero();

            InitHeroCamera(hero.View.gameObject.GetComponent<CameraHolder>());

            Transform weaponHolder = hero.View.gameObject.GetComponent<Hero>().WeaponHolder;

            GameEntity mainGun = CreateMainGun(weaponHolder, worldData, hero);

            CreateGun(weaponHolder, hero, ShootTypeId.Knife);
            CreateGun(weaponHolder, hero, ShootTypeId.WithoutGun);
            CreateGun(weaponHolder, hero, ShootTypeId.BigAxe);
            CreateGun(weaponHolder, hero, ShootTypeId.DefaultPistol);

            hero.AddAnimancerAnimator(mainGun.AnimancerAnimator);
            hero.AddCurrentGunId(mainGun.Id);

            InitEnemies();

            hero.AnimancerAnimator.StartAnimation(AnimationTypeId.Idle);
        }

        public void Update() => ExecuteBattleFeature();

        private GameEntity CreateHero() =>
            _heroFactory.Create(_levelDataProvider.StartPoint, _levelDataProvider.StartPoint.position,
                Quaternion.identity);

        private void InitEnemies() { }

        private GameEntity CreateGun(Transform weaponHolder, GameEntity hero, ShootTypeId shootTypeId) =>
            _shootFactory
                .Create(weaponHolder, shootTypeId, hero.Id)
                .With(x => x.isHeroGun = true);

        private GameEntity CreateMainGun(Transform weaponHolder, WorldData worldData, GameEntity hero)
        {
            GameEntity mainGun = _shootFactory
                    .Create(weaponHolder, worldData.PlayerData.LastWeaponId, hero.Id)
                    .With(x => x.isHeroGun = true)
                    .With(x => x.isShootCooldownUp = true)
                    .With(x => x.isActive = true)
                    .With(x => x.isViewActive = true)
                ;
            return mainGun;
        }

        private void CreateShootSwitching()
        {
            CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isShootSwitchingReady = true)
                .With(x => x.isShootSwitchingAvailable = true)
                .With(x => x.isConnectedWithHero = true)
                .With(x => x.isActive = true)
                .With(x => x.PutOnCooldown(0f))
                .With(x => x.isSwitchable = true);
        }

        private static void CreateInput()
        {
            CreateInputEntity.Empty()
                .With(x => x.AddMouseAxis(Vector2.zero))
                .isInput = true;
        }


        private void InitHeroCamera(CameraHolder cameraHolder)
        {
            _cameraFactory.CreateEntity(cameraHolder.MainCamera)
                .With(x => x.isConnectedWithHero = true);

            cameraHolder
                .With(cameraHolder => _cameraProvider.WeaponCamera = cameraHolder.WeaponCamera)
                .With(cameraHolder => _cameraProvider.Camera = cameraHolder.MainCamera)
                .With(cameraHolder => _cameraProvider.ShakeCamera = cameraHolder.ShakeCamera)
                .With(cameraHolder => _cameraProvider.RecoilRotator = cameraHolder.RecoilRotator)
                .With(cameraHolder => _cameraProvider.RecoilCamera = cameraHolder.RecoilCamera)
                .With(cameraHolder => _cameraProvider.CinemachineImpulseSource = cameraHolder.CinemachineImpulseSource);
        }

        private void ExecuteBattleFeature()
        {
            _battleFeature.Execute();
            _battleFeature.Cleanup();
        }

        protected override void Exit()
        {
            CleanupBattleFeature();
        }

        public void Dispose()
        {
            CleanupBattleFeature();
        }

        private void DestructEntities()
        {
            foreach (GameEntity entity in _game.GetEntities())
            {
                entity.isDestructed = true;
            }
        }

        private void CleanupBattleFeature()
        {
            _battleFeature.DeactivateReactiveSystems();
            _battleFeature.ClearReactiveSystems();

            DestructEntities();

            _battleFeature.Cleanup();
            _battleFeature.TearDown();
            _battleFeature = null;
        }

        private void CreateBattleFeature()
        {
            _battleFeature = _systemFactory.Create<BattleFeature>();

            _battleFeature.Initialize();
        }
    }
}