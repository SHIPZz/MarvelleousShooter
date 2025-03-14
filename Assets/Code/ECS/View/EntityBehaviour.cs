using Code.ECS.Common.Collisions;
using Code.ECS.View.Registrars;
using UnityEngine;
using Zenject;

namespace Code.ECS.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        private GameEntity _entity;

        public GameEntity Entity => _entity;

        private ICollisionRegistry _collisionRegistry;
        
        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity;
            _entity.AddView(this);
            _entity.Retain(this);

            foreach (IEntityComponentRegistrar entityComponentRegistrar in GetComponentsInChildren<IEntityComponentRegistrar>())
                entityComponentRegistrar.RegisterComponents();

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
        }

        public void ReleaseEntity()
        {
            foreach (IEntityComponentRegistrar entityComponentRegistrar in GetComponentsInChildren<IEntityComponentRegistrar>(true))
                entityComponentRegistrar.UnregisterComponents();

            foreach (Collider2D collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
                _collisionRegistry.Unregister(collider.GetInstanceID());

            _entity.RemoveView();
            _entity.Release(this);
            _entity = null;
            
        }
    }
}