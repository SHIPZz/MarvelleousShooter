using System.Collections.Generic;
using Code.Gameplay.Enemies.Factory;
using UnityEngine;

namespace Code.Gameplay.Enemies.Services
{
    public class EnemyService : IEnemyService
    {
        private readonly List<Enemy> _createdEnemies = new(256);
        private readonly IEnemyFactory _enemyFactory;

        public IReadOnlyList<Enemy> CreatedEnemies => _createdEnemies;

        public EnemyService(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public Enemy Create(EnemyTypeId id, Transform parent, Vector3 at, Quaternion rotation)
        {
            Enemy createdEnemy = _enemyFactory.Create(id, parent, at, rotation);

            _createdEnemies.Add(createdEnemy);

            return createdEnemy;
        }
    }
}