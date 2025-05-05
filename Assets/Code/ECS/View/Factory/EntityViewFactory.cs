using Code.InfraStructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.ECS.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly Vector3 _farAway =new Vector3(-999f,999,0);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity,Transform parent)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(entity.ViewPrefab, _farAway,
                Quaternion.identity, parent);
            
            view.SetEntity(entity);
            
            return view;
        }
        
        public EntityBehaviour CreateViewForEntityFromPath(GameEntity entity)
        {
            var prefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);

            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(prefab, _farAway,
                Quaternion.identity, null);
            
            view.SetEntity(entity);
            
            return view;
        }
        
        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(entity.ViewPrefab, entity.WorldPosition,
                Quaternion.identity, null);
            
            view.SetEntity(entity);
            
            return view;
        }
    }
}