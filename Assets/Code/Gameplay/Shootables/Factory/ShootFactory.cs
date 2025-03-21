using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.View;
using Code.ECS.View.Factory;
using Code.Extensions;
using Code.Gameplay.Animations;
using Code.Gameplay.Effects;
using Code.Gameplay.Shootables.Configs;
using Code.Gameplay.Shootables.Extensions;
using Code.Gameplay.Shootables.Services;
using Code.Gameplay.Shootables.Visuals;
using UnityEngine;
using Zenject;

// ReSharper disable All

namespace Code.Gameplay.Shootables.Factory
{
    public class ShootFactory : IShootFactory
    {
        private readonly ShootConfigs _shootConfigs;
        private readonly IInstantiator _instantiator;
        private IEntityViewFactory _entityViewFactory;
        private IIdentifierService _identifierService;

        public ShootFactory(IInstantiator instantiator,
            IIdentifierService identifierService,
            IEntityViewFactory entityViewFactory,
            ShootConfigs shootConfigs)
        {
            _identifierService = identifierService;
            _entityViewFactory = entityViewFactory;
            _instantiator = instantiator;
            _shootConfigs = shootConfigs;
        }

        public GameEntity Create(Transform parent, ShootTypeId shootTypeId, int ownerId)
        {
            ShootConfig config = _shootConfigs.GetById(shootTypeId);
            EntityBehaviour prefab = config.Prefab;

            GameEntity shootEntity = CreateEntity
                    .Empty()
                    .AddWorldPosition(Vector3.zero)
                    .AddOwnerId(ownerId)
                    .AddId(_identifierService.Next())
                    .AddViewPrefab(prefab)
                    .AddDamage(config.DamagePerHit)
                    .AddHits(null)
                    .AddShootDistance(config.ShootDistance)
                    .AddLayerMask(config.Mask)
                    .AddGunInputKey(config.InputKey)
                    .ReplaceLastShootTime(0)
                    .AddShootInterval(config.ShootInterval)
                    .With(x => x.AddAmmoCount(config.AmmoCount), when: config.AmmoCount > 0)
                    .PutOnAmmo()
                    .With(x => x.AddHitEffectTypeId(config.HitEffectTypeId), when: config.HitEffectTypeId != EffectTypeId.Unknown)
                    .With(x => x.isShootingReady = true)
                    .With(x => x.isNotAimable = !config.CanAim)
                    .With(x => x.isConnectedWithHero = true)
                    .With(x => x.isShootingAvailable = true)
                    .With(x => x.isShootable = true)
                    .With(x => x.isCanRaycast = config.CanRaycast)
                    .With(x => x.isReloadable = config.Reloadable)
                    .With(x => x.isAmmoAvailable = true, when: config.AmmoCount > 0)
                    .With(x => x.isShootWithoutAmmo = true, when: config.AmmoCount <= 0)
                    .With(x => x.isAimingAvailable = config.CanAim)
                    .With(x => x.isAimable = config.CanAim)
                    .With(x => x.isViewActive = true)
                    .With(x => x.isShootAnimationFinished = true)
                    .With(x => x.isCanRunAndShoot = config.CanRunAndShoot)
                    .With(x => x.isNeedAnimationComplete = config.NeedFullAnimationPlay)
                ;

            EntityBehaviour createdShoot = _entityViewFactory.CreateViewForEntityFromPrefab(shootEntity,parent);

            createdShoot.GetComponent<OnShootAnimationPlayer>().Init(config);

            createdShoot.Entity.Transform.localPosition = config.Position;
            createdShoot.Entity.Transform.localRotation = Quaternion.Euler(config.Rotation);

            return shootEntity;
        }
    }
}