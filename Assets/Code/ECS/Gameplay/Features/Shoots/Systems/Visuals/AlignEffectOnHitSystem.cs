using System.Collections.Generic;
using Code.ECS.Extensions;
using Code.ECS.Gameplay.Features.Effects;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Visuals
{
    public class AlignEffectOnHitSystem : ReactiveSystem<GameEntity>
    {
        private readonly IEffectViewFactory _effectFactory;
        
        public AlignEffectOnHitSystem(IContext<GameEntity> game, IEffectViewFactory effectFactory) : base(game)
        {
            _effectFactory = effectFactory;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.HitDetected.Added());

        protected override bool Filter(GameEntity entity) => !entity.Hits.IsNullOrEmpty() 
                                                             && entity.isGun
                                                             && entity.isActive
                                                             && entity.hasHitEffectTypeId;

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                var hits = entity.Hits;
                
                _effectFactory.Create(entity.HitEffectTypeId, null,
                    hits[0].point,
                    Quaternion.LookRotation(hits[0].normal));
                
                return;
            }
        }
    }
    
}