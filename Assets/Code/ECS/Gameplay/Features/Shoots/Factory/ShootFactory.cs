using System;
using System.Collections.Generic;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Shoots.Configs;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Code.ECS.Gameplay.Features.Shoots.Extensions;
using Code.ECS.View;
using Code.ECS.View.Factory;
using Code.Extensions;
using DG.Tweening;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Factory
{
    public class ShootFactory : IShootFactory
    {
        private readonly ShootConfigs _shootConfigs;
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IIdentifierService _identifierService;

        public ShootFactory(IIdentifierService identifierService,
            IEntityViewFactory entityViewFactory,
            ShootConfigs shootConfigs)
        {
            _identifierService = identifierService;
            _entityViewFactory = entityViewFactory;
            _shootConfigs = shootConfigs;
        }

        public GameEntity Create(Transform parent, GunTypeId gunTypeId, int ownerId)
        {
            ShootConfig config = _shootConfigs.GetById(gunTypeId);
            EntityBehaviour prefab = config.Prefab;

            RecoilData recoilData = config.RecoilData;

            switch (gunTypeId)
            {
                case GunTypeId.BasicRifle:
                    return CreateBasicRifle(parent, ownerId, prefab, config, recoilData);

                case GunTypeId.Knife:
                    return CreateKnife(parent, ownerId, prefab, config, recoilData);

                case GunTypeId.Grenade:
                    break;

                case GunTypeId.SmallAxe:
                    break;

                case GunTypeId.BigAxe:
                    return CreateBigAxe(parent, ownerId, prefab, config, recoilData);

                case GunTypeId.SniperRifle:
                    break;

                case GunTypeId.GrenadeGun:
                    break;

                case GunTypeId.ShotGun:
                    break;

                case GunTypeId.WithoutGun:
                    return CreateWithoutGun(parent, ownerId, prefab, config, recoilData);
                
                case GunTypeId.DefaultPistol:
                    return CreateDefaultPistol(parent, ownerId, prefab, config, recoilData);
                    

                default:
                    throw new ArgumentNullException(nameof(gunTypeId));
            }

            throw new ArgumentNullException(nameof(gunTypeId));
        }

        private GameEntity CreateDefaultPistol(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config, RecoilData recoilData)
        {
            return CreateGun(parent, ownerId, prefab, config, recoilData)
                .With(x => x.isCastFromCamera = true);
        }

        private GameEntity CreateBigAxe(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config,
            RecoilData recoilData)
        {
            return CreateGun(parent, ownerId, prefab, config, recoilData)
                    .With(x => x.isOnAnimationEndCast = true)
                    .With(x => x.isCastFromCamera = true)
                ;
        }

        private GameEntity CreateKnife(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config,
            RecoilData recoilData)
        {
            return CreateGun(parent, ownerId, prefab, config, recoilData)
                    .With(x => x.isOnAnimationEndCast = true)
                    .With(x => x.isDoubleShootingAvailable = true)
                    .With(x => x.isCastFromCamera = true)
                ;
        }

        private GameEntity CreateWithoutGun(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config,
            RecoilData recoilData)
        {
            return CreateGun(parent, ownerId, prefab, config, recoilData)
                    .With(x => x.isOnAnimationEndCast = true)
                    .With(x => x.isCastFromCamera = true)
                    .With(x => x.isDoubleShootingAvailable = true)
                ;
        }

        private GameEntity CreateBasicRifle(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config,
            RecoilData recoilData)
        {
            return CreateGun(parent, ownerId, prefab, config, recoilData)
                .With(x => x.isCastFromCamera = true);
        }

        private GameEntity CreateGun(Transform parent, int ownerId, EntityBehaviour prefab, ShootConfig config,
            RecoilData recoilData)
        {
            GameEntity gun = CreateEntity
                    .Empty()
                    .AddOwnerId(ownerId)
                    .AddId(_identifierService.Next())
                    .AddViewPrefab(prefab)
                    .AddWorldPosition(Vector3.zero)
                    .AddDamage(config.DamagePerHit)
                    .AddHits(new List<RaycastHit>(16))
                    .AddRecoilData(recoilData)
                    .AddShootDistance(config.ShootDistance)
                    .AddLayerMask(config.Mask)
                    .AddCollectTargetsLayerMask(config.Mask)
                    .AddGunInputKey(config.InputKey)
                    .AddRecoilRecoverySpeed(recoilData.RecoverSpeed)
                    .AddShootCooldown(config.Сooldown)
                    .AddShootCooldownLeft(0)
                    .AddRecoilPatternIndex(0)
                    .AddMoveGunDuration(config.MoveGunDuration)
                    .AddMoveGunPosition(config.MoveGunPosition)
                    .With(x => x.AddAmmoCount(config.AmmoCount), when: config.AmmoCount > 0)
                    .PutOnAmmo()
                    .With(x => x.AddHitEffectTypeId(config.HitEffectTypeId),
                        when: config.HitEffectTypeId != EffectTypeId.None)
                    .With(x => x.isNotAimable = !config.CanAim)
                    .With(x => x.isConnectedWithHero = true)
                    .With(x => x.AddPatterns(recoilData.Patterns), when: !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.AddVerticalRecoil(0), when: !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.AddHorizontalRecoil(0), when: !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.AddCurrentRecoil(Vector3.zero), when: !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.AddTargetRecoil(Vector3.zero), when: !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.AddRecoilSpeed(recoilData.Speed), when: recoilData.Speed > 0)
                    .With(x => x.AddAimMultiplier(recoilData.AimMultiplier), when: recoilData.AimMultiplier > 0)
                    .With(x => x.AddAimJumpMultiplier(recoilData.AimJumpMultiplier),
                        when: recoilData.AimJumpMultiplier > 0)
                    .With(x => x.AddJumpMultiplier(recoilData.JumpMultiplier), when: recoilData.JumpMultiplier > 0)
                    .With(x => x.AddMinHorizontalRecoilOnJump(recoilData.MinHorizontalRecoilOnJump),
                        when: recoilData.MinHorizontalRecoilOnJump > 0)
                    .With(x => x.AddMinVerticalRecoilOnJump(recoilData.MinHorizontalRecoilOnJump),
                        when: recoilData.MinVerticalRecoilOnJump > 0)
                    .With(x => x.isShootingAvailable = true)
                    .With(x => x.isGun = true)
                    .With(x => x.isHasRecoil = !recoilData.Patterns.IsNullOrEmpty())
                    .With(x => x.isShootCooldownUp = true)
                    .With(x => x.isCanRaycast = config.CanRaycast)
                    .With(x => x.isReloadable = config.Reloadable)
                    .With(x => x.isAmmoAvailable = true, when: config.AmmoCount > 0)
                    .With(x => x.isShootWithoutAmmo = true, when: config.AmmoCount <= 0)
                    .With(x => x.isAimingAvailable = config.CanAim)
                    .With(x => x.isAimable = config.CanAim)
                    .With(x => x.isViewActive = false)
                    .With(x => x.isHasIdleFocus = config.HasIdleFocus)
                    .With(x => x.isPositionFixed = true)
                    .With(x => x.isCanRunAndShoot = config.CanRunAndShoot)
                ;


            EntityBehaviour createdShoot = _entityViewFactory.CreateViewForEntityFromPrefab(gun, parent);

            createdShoot.Entity.Transform.localPosition = config.Position;
            createdShoot.Entity.Transform.localRotation = Quaternion.Euler(config.Rotation);
            gun.ReplaceInitialLocalPosition(createdShoot.Entity.Transform.localPosition);

            AddMoveRecoilTween(gun);
            return gun;
        }

        private static void AddMoveRecoilTween(GameEntity gun)
        {
            Sequence recoilSequence = DOTween.Sequence();

            recoilSequence
                .Append(gun.Transform.DOLocalMove(gun.InitialLocalPosition + gun.MoveGunPosition, gun.MoveGunDuration))
                .Append(gun.Transform.DOLocalMove(gun.InitialLocalPosition, gun.MoveGunDuration))
                .SetAutoKill(false)
                .Pause();


            gun.AddMoveRecoilTween(recoilSequence);
        }
    }
}