using CodeBase.Extensions;
using CodeBase.Gameplay.Common.Damage;
using CodeBase.Gameplay.Shootables.Configs;
using CodeBase.Gameplay.Shootables.Recoils;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.Visuals;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Factory
{
    public class ShootFactory : IShootFactory
    {
        private readonly ShootConfigs _shootConfigs;
        private readonly IInstantiator _instantiator;
        private readonly IShootService _shootService;

        public ShootFactory(IInstantiator instantiator,
            IShootService shootService,
            ShootConfigs shootConfigs)
        {
            _shootService = shootService;
            _instantiator = instantiator;
            _shootConfigs = shootConfigs;
        }

        public Shoot Create(Transform parent, ShootTypeId shootTypeId)
        {
            ShootConfig config = _shootConfigs.GetById(shootTypeId);
            Shoot prefab = config.Prefab;

            Shoot createdShoot = _instantiator
                    .InstantiatePrefabForComponent<Shoot>(prefab, prefab.transform.position, prefab.transform.rotation, parent)
                    .With(x => x.GetComponent<Recoil>().Init(config.RecoilData))
                    .With(apply: x => x.transform.localPosition = config.Position, @when: config.Position != Vector3.zero)
                    .With(apply: x => x.transform.localRotation = Quaternion.Euler(config.Rotation), @when: config.Rotation != Vector3.zero)
                    .With(x => x.GetComponent<DamageDealer>().Init(config.DamagePerHit))
                    .With(x => x.ShootInterval = config.ShootInterval)
                    .With(x => x.Id = config.ShootTypeId)
                    .With(x => x.MarkShootingActive(false))
                    .With(x => x.ShowInputKey = config.ShowKey)
                ;

            if (createdShoot.TryGetComponent(out AmmoCount ammoCount))
                ammoCount.Init(config.AmmoCount);

            ReloadAmmoCount reloadAmmoCount = createdShoot.GetComponent<ReloadAmmoCount>();

            var animator = SetupAnimator(createdShoot, reloadAmmoCount);

            createdShoot.GetComponent<OnShootAnimationPlayer>().Init(config);

            _shootService.IsShootingAvailable = true;
            
            return createdShoot.With(x => x.Init(config.ShootDistance, config.Mask));
        }

        private ShootAnimator SetupAnimator(Shoot createdShoot, ReloadAmmoCount reloadAmmoCount)
        {
            ShootAnimator shootAnimator = createdShoot.GetComponent<ShootAnimator>();

            return shootAnimator
                    .With(animator => _shootService.Animator = animator)
                    .With(animator => reloadAmmoCount.SetReloadTime(animator.GetState(AnimationTypeId.Reload).Duration),
                        when: reloadAmmoCount != null)
                ;
        }
    }
}