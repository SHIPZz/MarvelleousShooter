using System;
using CodeBase.Gameplay.AbilitySystem.StatSystem;
using CodeBase.Gameplay.Healths;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Common.Damage
{
    public class DamageDealer : MonoBehaviour
    {
        protected Health TargetHealth;

        [SerializeField] private Stats _stats;

        public event Action<Health> TargetDamaged; 

        private IDamageService _damageService;

        [Inject]
        private void Construct(IDamageService damageService)
        {
            _damageService = damageService;
        }
        
        public void Init(float damage)
        {
            _stats.AddBaseStat(StatTypeId.Damage, damage);
        }

        public void Do(int hitCount, RaycastHit[] raycastHits)
        {
            var baseDamage = _stats.GetStatValue(StatTypeId.Damage);
            
                _damageService.ApplyDamage(raycastHits[0], baseDamage, out TargetHealth);
            
            
            TargetDamaged?.Invoke(TargetHealth);
        }
    }
}