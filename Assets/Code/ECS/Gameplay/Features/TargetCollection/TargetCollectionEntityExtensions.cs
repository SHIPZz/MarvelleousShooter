using System.Collections.Generic;
using Code.ECS.Extensions;

namespace Code.ECS.Gameplay.Features.TargetCollection
{
    public static class TargetCollectionEntityExtensions
    {
        public static GameEntity SetupTargetCollectionComponents(this GameEntity entity, int layerMask, float interval = 0.5f)
        {
           return entity
                .With(x => x.AddTargetsBuffer(new List<int>(10)))
                .With(x => x.AddCollectTargetsInterval(interval), when: interval > 0)
                .With(x => x.AddCollectTargetsTimer(0))
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingAvailable = true)
                .AddCollectTargetsLayerMask(layerMask)
                ;
        }
        
        public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
        {
            if (entity.hasTargetsBuffer)
                entity.RemoveTargetsBuffer();

            if (entity.hasCollectTargetsInterval)
                entity.RemoveCollectTargetsInterval();
            
            if (entity.hasCollectTargetsTimer)
                entity.RemoveCollectTargetsTimer();

            entity.isReadyToCollectTargets = false;
            
            return entity;
        }
    }
}