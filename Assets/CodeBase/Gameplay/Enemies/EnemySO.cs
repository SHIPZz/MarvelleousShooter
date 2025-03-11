using UnityEngine;

namespace CodeBase.Gameplay.Enemies
{
    [CreateAssetMenu(fileName = "EnemySO", menuName = "Gameplay/EnemySO", order = 1)]
    public class EnemySO : ScriptableObject
    {
        public Enemy Prefab;
        public EnemyTypeId Id;
    }
}