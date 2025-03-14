using Code.Gameplay.Healths;
using Code.Gameplay.Heroes.Services;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public Health Health { get; private set; }
        [field: SerializeField] public EnemyTypeId Id { get; private set; }
        
        [Inject] public IHeroService heroProvider { get; }
    }
}
