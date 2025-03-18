using UnityEngine;

namespace Code.ECS.View.Factory
{
    public interface IEntityViewFactory
    {
        EntityBehaviour CreateViewForEntityFromPath(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity,Transform parent);
    }
}