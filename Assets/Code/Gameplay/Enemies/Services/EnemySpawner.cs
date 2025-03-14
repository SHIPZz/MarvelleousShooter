using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemies.Services
{
    public class EnemySpawner : MonoBehaviour, IInitializable
    {
        [SerializeField] private EnemyTypeId _enemyTypeId = EnemyTypeId.Goblin;

        private IEnemyService _enemyService;

        [Inject]
        private void Construct(IEnemyService enemyService)
        {
            _enemyService = enemyService;
        }

        public void Initialize()
        {
            //_enemyService.Create(_enemyTypeId, transform, transform.position, Quaternion.identity);
        }

        public void Spawn() => _enemyService.Create(_enemyTypeId, transform, transform.position, Quaternion.identity);
}
}