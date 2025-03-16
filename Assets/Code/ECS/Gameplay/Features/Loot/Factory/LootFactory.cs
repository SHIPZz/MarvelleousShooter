using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Gameplay.Features.CharacterStats;
using Code.ECS.Gameplay.Features.Loot.Configs;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Loot.Factory
{
    public class LootFactory : ILootFactory
    {
        private readonly IIdentifierService _identifierService;
        // private readonly IStaticDataService _staticDataService;

        // public LootFactory(IIdentifierService identifierService, IStaticDataService staticDataService)
        // {
            // _staticDataService = staticDataService;
            // _identifierService = identifierService;
        // }

        public GameEntity CreateLootItem(LootTypeId lootTypeId, Vector3 at)
        {
            // LootConfig lootConfig = _staticDataService.GetLootConfig(lootTypeId);
            //
            // var baseStats = InitStats.EmptyStatDictionary()
            //     .With( x=> x[Stats.Speed] = 3)
            //     ;
            
           return  CreateEntity
                .Empty()
                // .AddId(_identifierService.Next())
                // .AddWorldPosition(at)
                // .AddSpeed(baseStats[Stats.Speed])
                // .AddBaseStats(baseStats)
                // .AddStatModifiers(InitStats.EmptyStatDictionary())
                // .AddLootTypeId(lootTypeId)
                // .AddViewPrefab(lootConfig.ViewPrefab)
                // .AddAnimationDuration(lootConfig.AnimationDuration)
                // .AddAnimationCurve(lootConfig.AnimationCurve)
                // .AddElapsedTime(0f)
                // .With(x => x.AddStartHeight(x.WorldPosition.y))
                // .With(x => x.AddExperience(lootConfig.Experience), when: lootConfig.Experience > 0)
                // .With(x => x.AddEffectSetups(lootConfig.EffectSetups), when: !lootConfig.EffectSetups.IsNullOrEmpty())
                // .With(x => x.AddStatusSetups(lootConfig.StatusSetups), when: !lootConfig.StatusSetups.IsNullOrEmpty())
                // .With(x => x.isPullable = true)
                // .With(x => x.isUpdateHeightBySinCurve = true)
                
                ;
        }
    }
}