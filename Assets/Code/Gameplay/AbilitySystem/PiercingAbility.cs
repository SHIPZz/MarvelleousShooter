using Code.Gameplay.AbilitySystem.StatSystem;
using Code.Gameplay.Common.Configs;
using Code.Gameplay.Common.Damage;
using Code.Gameplay.Healths;
using Code.Gameplay.Shootables;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.AbilitySystem
{
    public class PiercingAbility : AbstractAbility
    {
        private DamageConfig _damageConfig;
        private bool _lastShotThroughObject;
        private Shoot _shoot;
        private Stats _stats;
        private IDamageNotifierService _damageNotifierService;
        private CompositeDisposable _compositeDisposable = new();

        public override AbilityTypeId AbilityType { get; protected set; } = AbilityTypeId.Pierce;
        public override bool IsAlwaysActive { get; protected set; } = true;

        [Inject]
        private void Construct(DamageConfig damageConfig, IDamageNotifierService damageNotifierService)
        {
            _damageNotifierService = damageNotifierService;
            _damageConfig = damageConfig;
        }
        
        public override void OnGained(AbilityOwner AbilityOwner)
        {
            _shoot = AbilityOwner.GetComponentInChildren<Shoot>();
            _stats = _shoot.GetComponent<Stats>();
            _shoot.ShootWithHitsEvent.Subscribe(ApplyPiercingDamage).AddTo(_compositeDisposable);
        }

        public override void OnLose()
        {
            _compositeDisposable?.Dispose();
        }

        public override void Dispose()
        {
            base.Dispose();
            _compositeDisposable?.Dispose();
        }

        private void ApplyPiercingDamage(RaycastHit[] hits)
        {
            float baseDamage = _stats.GetBaseValue(StatTypeId.Damage);
            float finalDamage = baseDamage;
            
            foreach (var hit in hits)
            {
                if (hit.collider == null)
                    continue;

                finalDamage = CalculateDamageByDistance(hit, finalDamage);

                finalDamage = finalDamage < 0 ? 0 : finalDamage;

                if (CanDoDamage(hit, out Health health))
                {
                    health.Decrease(finalDamage);
                    
                    if (_lastShotThroughObject)
                        _damageNotifierService.NotifyPiercingDamage(health);
                    else
                        _damageNotifierService.NotifyDamaged(health);

                    return;
                }

                if (!CheckThickness(hit, out var thickness))
                    return;

                finalDamage = CalculateDamageByThickness(baseDamage, thickness, finalDamage);

                _lastShotThroughObject = true;
            }
        }
        
        private float CalculateDamageByThickness(float baseDamage, float thickness, float finalDamage)
        {
            float reductionFromThickness = baseDamage * Mathf.Pow(thickness / _damageConfig.MaxThickness, 3) * _damageConfig.DamageReductionPerObject;

            finalDamage = Mathf.Clamp(finalDamage - reductionFromThickness, 0, baseDamage);
            return finalDamage;
        }

        private bool CheckThickness(RaycastHit hit, out float thickness)
        {
            thickness = GetThickness(hit);

            if (thickness > _damageConfig.MaxThickness)
            {
                _lastShotThroughObject = false;
                return false;
            }

            return true;
        }

        private static bool CanDoDamage(RaycastHit hit, out Health health)
        {
            return hit.collider.gameObject.TryGetComponent(out health) && !health.Dead;
        }

        private float GetThickness(RaycastHit hit)
        {
            if (hit.collider is BoxCollider boxCollider)
            {
                return Mathf.Max(boxCollider.bounds.size.x, boxCollider.bounds.size.y, boxCollider.bounds.size.z);
            }

            if (hit.collider is SphereCollider sphereCollider)
            {
                return sphereCollider.radius * 2;
            }

            if (hit.collider is CapsuleCollider capsuleCollider)
            {
                return capsuleCollider.height;
            }

            return hit.collider.bounds.size.magnitude;
        }

        private float CalculateDamageByDistance(RaycastHit hit, float finalDamage)
        {
            finalDamage -= _damageConfig.DamageReductionPerMeter * hit.distance;
            return finalDamage;
        }
    }
}