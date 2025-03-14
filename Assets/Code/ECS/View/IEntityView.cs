using UnityEngine;

namespace Code.ECS.View
{
    public interface IEntityView
    {
        void SetEntity(GameEntity entity);
        void ReleaseEntity();
        GameEntity Entity { get; }
        
        GameObject gameObject { get; }
    }
}