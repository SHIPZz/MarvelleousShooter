using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Common
{
    public class GetClosestEntityService : IGetClosestEntityService
    {
        public GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            // foreach (GameEntity enemy in enemies)
            // {
            //     float distanceToTarget = Vector3.Distance(entity.WorldPosition, entity.WorldPosition);
            //
            //     if (distanceToTarget <= maxDistance)
            //     {
            //         maxDistance = distanceToTarget;
            //         closestEnemy = enemy;
            //     }
            // }

            return closestEnemy;
        }
        
        public GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies, int skipId)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;
            
            // foreach (GameEntity enemy in enemies)
            // {
            //     if(enemy.Id == skipId)
            //         continue;
            //     
            //     float distanceToTarget = Vector3.Distance(enemy.WorldPosition, entity.WorldPosition);
            //
            //     if (distanceToTarget <= maxDistance)
            //     {
            //         maxDistance = distanceToTarget;
            //         closestEnemy = enemy;
            //     }
            // }

            return closestEnemy;
        }
        
        public GameEntity GetClosestEntity(GameEntity entity, IGroup<GameEntity> enemies, List<int> skipIds)
        {
            float maxDistance = float.MaxValue;
            GameEntity closestEnemy = null;

            // foreach (GameEntity enemy in enemies)
            // {
            //     if(skipIds.Contains(enemy.Id))
            //         continue;
            //     
            //     float distanceToTarget = Vector3.Distance(enemy.WorldPosition, entity.WorldPosition);
            //
            //     if (distanceToTarget <= maxDistance)
            //     {
            //         maxDistance = distanceToTarget;
            //         closestEnemy = enemy;
            //     }
            // }

            return closestEnemy;
        }
    }
}