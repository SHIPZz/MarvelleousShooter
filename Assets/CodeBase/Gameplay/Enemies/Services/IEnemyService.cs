using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Gameplay.Enemies.Services
{
    public interface IEnemyService
    {
        Enemy Create(EnemyTypeId id, Transform parent, Vector3 at, Quaternion rotation);
        IReadOnlyList<Enemy> CreatedEnemies { get; }
    }
}