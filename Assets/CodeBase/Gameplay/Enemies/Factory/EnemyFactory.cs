using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Enemies.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IEnemyStaticDataService _enemyStaticDataService;

        public EnemyFactory(IInstantiator instantiator, IEnemyStaticDataService enemyStaticDataService)
        {
            _instantiator = instantiator;
            _enemyStaticDataService = enemyStaticDataService;
        }
        
        public Enemy Create(EnemyTypeId id, Transform parent, Vector3 at, Quaternion rotation)
        {
            var enemyData = _enemyStaticDataService.Get(id);

            return _instantiator.InstantiatePrefabForComponent<Enemy>(enemyData.Prefab, at, rotation, parent);
        }
    }
}