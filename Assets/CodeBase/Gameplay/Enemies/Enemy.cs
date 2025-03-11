using CodeBase.Gameplay.Healths;
using CodeBase.Gameplay.Heroes.Services;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Enemies
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public Health Health { get; private set; }
        [field: SerializeField] public EnemyTypeId Id { get; private set; }
        
        [Inject] public IHeroService heroProvider { get; }
    }
}
