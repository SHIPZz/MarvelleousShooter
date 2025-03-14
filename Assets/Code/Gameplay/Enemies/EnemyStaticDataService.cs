using System.Collections.Generic;
using System.Linq;
using Code.Constant;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public interface IEnemyStaticDataService
    {
        EnemySO Get(EnemyTypeId id);
    }

    public class EnemyStaticDataService : IEnemyStaticDataService
    {
        private readonly Dictionary<EnemyTypeId, EnemySO> _enemies;

        public EnemyStaticDataService()
        {
            _enemies = Resources.LoadAll<EnemySO>(AssetPath.Enemies)
                .ToDictionary(x => x.Id, x => x);
        }

        public EnemySO Get(EnemyTypeId id) => _enemies[id];
    }
}