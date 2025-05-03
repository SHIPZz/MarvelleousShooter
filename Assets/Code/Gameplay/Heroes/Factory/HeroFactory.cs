using System.Collections.Generic;
using Code.Data.Services;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Gameplay.Features.CharacterStats;
using Code.ECS.View;
using Code.ECS.View.Factory;
using Code.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.Heroes.Configs;
using Code.SaveData;
using KinematicCharacterController.Examples;
using UnityEngine;

namespace Code.Gameplay.Heroes.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly HeroConfig _heroConfig;
        private readonly IWorldDataService _worldDataService;
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IIdentifierService _identifierService;

        public HeroFactory(HeroConfig heroConfig, 
            IIdentifierService identifierService,
            IEntityViewFactory entityViewFactory,
            IWorldDataService worldDataService
            )
        {
            _identifierService = identifierService;
            _entityViewFactory = entityViewFactory;
            _worldDataService = worldDataService;
            _heroConfig = heroConfig;
        }

        public GameEntity Create(Transform parent, Vector3 at, Quaternion rotation)
        {
            WorldData worldData = _worldDataService.Get();
            
            EntityBehaviour prefab = _heroConfig.Prefab;

            Dictionary<Stats, float> stats = InitStats.EmptyStatDictionary();
            Dictionary<Stats, float> statModifiers = InitStats.EmptyStatDictionary();

            stats[Stats.Hp] = worldData.PlayerData.Hp;
            stats[Stats.MaxHp] = _heroConfig.Hp;
            stats[Stats.Speed] = _heroConfig.MovementData.Speed;
            
            GameEntity heroEntity = CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddRotation(rotation)
                .AddBaseStats(stats)
                .AddStatModifiers(statModifiers)
                .AddWorldPosition(at)
                .AddVerticalRotation(0)
                .AddCurrentHp(stats[Stats.Hp])
                .AddMaxHp(stats[Stats.MaxHp])
                .AddSpeed(stats[Stats.Speed])
                .AddInitialSpeed(stats[Stats.Speed])
                .AddAvailableShoots(worldData.PlayerData.AvailableShoots)
                .AddCurrentShootTypeId(worldData.PlayerData.LastWeaponId)
                .With(x => x.isHero = true)
                .With(x => x.isRunningAvailable = true)
                .With(x => x.isMovingAvailable = true)
                .With(x => x.isIdleAvailable = true)
                .With(x => x.isViewActive = true)
                .With(x => x.isActive = true)
                .With(x => x.isAlive = true)
                .With(x => x.isOnGround = true)
                .With(x => x.isShootHolder = true)
                .With(x => x.isCanRun = true)
                .AddViewPrefab(prefab);
            
           var createdHero = _entityViewFactory.CreateViewForEntityFromPrefab(heroEntity);

           createdHero.transform.position = at;
            

            return heroEntity
                .With(x => x.AddCameraHolder(createdHero.GetComponent<CameraHolder>()))
                .With(x => x.AddCharacterController(createdHero.GetComponent<CharacterController>()))
                .With(x => createdHero.gameObject.SetActive(true))
                //.With(x => x.AddCharacterMovement(createdHero.GetComponent<CharacterMovement>()))
                ;
        }
    }
}