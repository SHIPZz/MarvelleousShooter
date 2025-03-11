using CodeBase.Gameplay.AbilitySystem.StatSystem;
using CodeBase.Gameplay.AbilitySystem.StatSystem.StatModifiers;
using CodeBase.Gameplay.Common.Configs;
using CodeBase.Gameplay.Healths;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Damage
{
    public class DamageService : IDamageService
    {
        private readonly DamageConfig _damageConfig;
        private readonly IStatService _statService;

        public DamageService(DamageConfig damageConfig, IStatService statService)
        {
            _statService = statService;
            _damageConfig = damageConfig;
        }

        public void ApplyDamage(RaycastHit hit, float baseDamage, out Health target)
        {
            baseDamage =  _statService.GetStatValue(StatTypeId.Damage);
            
            float finalDamage = baseDamage;
            
            target = null;

            if (hit.collider == null)
                return;

            if (!CanDoDamage(hit, out Health health))
                return;

            target = health;
            finalDamage = CalculateDamageByDistance(hit, finalDamage);

            finalDamage = finalDamage < 0 ? 0 : finalDamage;

            health.Decrease(finalDamage);
        }
        
        private static bool CanDoDamage(RaycastHit hit, out Health health)
        {
            return hit.collider.gameObject.TryGetComponent(out health) && !health.Dead;
        }

        private float CalculateDamageByDistance(RaycastHit hit, float finalDamage)
        {
            finalDamage -= _damageConfig.DamageReductionPerMeter * hit.distance;
            return finalDamage;
        }
    }
}