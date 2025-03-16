using Code.Gameplay.Healths;
using UnityEngine;

namespace Code.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public Health Health { get; private set; }
        [field: SerializeField] public EnemyTypeId Id { get; private set; }
        
    }
}
