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
using ECM.Components;
using UnityEngine;

namespace Code.Gameplay.Heroes.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly HeroConfig _heroConfig;
        private readonly IWorldDataService _worldDataService;
        private IEntityViewFactory _entityViewFactory;
        private IIdentifierService _identifierService;

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

            stats[Stats.Hp] = worldData.PlayerData.Hp;
            stats[Stats.MaxHp] = _heroConfig.Hp;
            
            GameEntity heroEntity = CreateEntity
                .Empty()
                .AddId(_identifierService.Next())
                .AddRotation(rotation)
                .AddBaseStats(stats)
                .AddWorldPosition(at)
                .AddCurrentHp(stats[Stats.Hp])
                .AddMaxHp(stats[Stats.MaxHp])
                .AddAvailableShoots(worldData.PlayerData.AvailableShoots)
                .AddCurrentShootTypeId(worldData.PlayerData.LastWeaponId)
                .With(x => x.isHero = true)
                .With(x => x.isRunningAvailable = true)
                .With(x => x.isMovingAvailable = true)
                .With(x => x.isIdleAvailable = true)
                .With(x => x.isCanRun = true)
                .AddViewPrefab(prefab);
            
           var createdHero = _entityViewFactory.CreateViewForEntityFromPrefab(heroEntity);

           createdHero.transform.position = at;
            

            return heroEntity
                .With(x => x.AddCameraHolder(createdHero.GetComponent<CameraHolder>()))
                .With(x => x.AddCharacterMovement(createdHero.GetComponent<CharacterMovement>()))
                ;
        }
    }
}