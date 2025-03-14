using UnityEngine;

namespace Code.Gameplay.Enemies.Factory
{
    public interface IEnemyFactory
    {
        Enemy Create(EnemyTypeId id, Transform parent, Vector3 at, Quaternion rotation);
    }
}