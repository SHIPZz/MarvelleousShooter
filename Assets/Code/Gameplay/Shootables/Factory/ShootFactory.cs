using System.Collections.Generic;
using System.Linq;
using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.View;
using Code.ECS.View.Factory;
using Code.Extensions;
using Code.Gameplay.Cameras;
using Code.Gameplay.Effects;
using Code.Gameplay.Shootables.Configs;
using Code.Gameplay.Shootables.Extensions;
using Code.Gameplay.Shootables.Recoils;
using UnityEngine;

namespace Code.Gameplay.Shootables.Factory
{
    public class ShootFactory : IShootFactory
    {
        private readonly ShootConfigs _shootConfigs;
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly IIdentifierService _identifierService;
        private readonly ICameraProvider _cameraProvider;

        public ShootFactory(IIdentifierService identifierService,
            IEntityViewFactory entityViewFactory,
            ICameraProvider cameraProvider,
            ShootConfigs shootConfigs)
        {
            _cameraProvider = cameraProvider;
            _identifierService = identifierService;
            _entityViewFactory = entityViewFactory;
            _shootConfigs = shootConfigs;
        }

        public GameEntity Create(Transform parent, ShootTypeId shootTypeId, int ownerId)
        {
            ShootConfig config = _shootConfigs.GetById(shootTypeId);
            EntityBehaviour prefab = config.Prefab;

            RecoilData recoilData = config.RecoilData;

            GameEntity shootEntity = CreateEntity
                    .Empty()
                    .AddWorldPosition(Vector3.zero)
                    .AddOwnerId(ownerId)
                    .AddId(_identifierService.Next())
                    .AddViewPrefab(prefab)
                    .AddDamage(config.DamagePerHit)
                    .AddHits(new List<RaycastHit>(16))
                    .AddRecoilData(recoilData)
                    .AddShootDistance(config.ShootDistance)
                    .AddLayerMask(config.Mask)
                    .AddGunInputKey(config.InputKey)
                    .ReplaceLastShootTime(0)
                    .AddPatterns(recoilData.Patterns.ToArray())
                    .AddRecoilSpeed(recoilData.Speed)
                    .AddMinHorizontalRecoilOnJump(recoilData.MinHorizontalRecoilOnJump)
                    .AddAimMultiplier(recoilData.AimMultiplier)
                    .AddAimJumpMultiplier(recoilData.AimJumpMultiplier)
                    .AddJumpMultiplier(recoilData.JumpMultiplier)
                    .AddCurrentRecoil(Vector3.zero)
                    .AddTargetRecoil(Vector3.zero)
                    .AddTotalHorizontalRecoil(0)
                    .AddTotalVerticalRecoil(0)
                    .AddHorizontalRecoil(0)
                    .AddVerticalRecoil(0)
                    .AddRecoilProgress(0)
                    .AddRecoilRecoverySpeed(recoilData.RecoverSpeed)
                    .AddShootCooldown(config.Сooldown)
                    .AddShootCooldownLeft(0)
                    .AddRecoilPatternIndex(0)
                    .With(x => x.AddAmmoCount(config.AmmoCount), when: config.AmmoCount > 0)
                    .PutOnAmmo()
                    .With(x => x.AddHitEffectTypeId(config.HitEffectTypeId), when: config.HitEffectTypeId != EffectTypeId.Unknown)
                    .With(x => x.isNotAimable = !config.CanAim)
                    .With(x => x.isConnectedWithHero = true)
                    .With(x => x.isShootingAvailable = true)
                    .With(x => x.isShootable = true)
                    .With(x => x.isHasRecoil = true)
                    .With(x => x.isShootCooldownUp = true)
                    .With(x => x.isCanRaycast = config.CanRaycast)
                    .With(x => x.isReloadable = config.Reloadable)
                    .With(x => x.isAmmoAvailable = true, when: config.AmmoCount > 0)
                    .With(x => x.isShootWithoutAmmo = true, when: config.AmmoCount <= 0)
                    .With(x => x.isAimingAvailable = config.CanAim)
                    .With(x => x.isAimable = config.CanAim)
                    .With(x => x.isViewActive = true)
                    .With(x => x.isCanRunAndShoot = config.CanRunAndShoot)
                ;

            
            EntityBehaviour createdShoot = _entityViewFactory.CreateViewForEntityFromPrefab(shootEntity, parent);
            
            createdShoot.Entity.Transform.localPosition = config.Position;
            createdShoot.Entity.Transform.localRotation = Quaternion.Euler(config.Rotation);
            shootEntity.ReplaceInitialLocalPosition(createdShoot.Entity.Transform.localPosition);

            return shootEntity;
        }
    }
}