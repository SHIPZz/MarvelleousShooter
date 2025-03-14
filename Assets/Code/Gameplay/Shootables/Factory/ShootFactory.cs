using Code.ECS.Common.Entity;
using Code.ECS.Common.Services;
using Code.ECS.View;
using Code.ECS.View.Factory;
using Code.Extensions;
using Code.Gameplay.Animations;
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
        private readonly IShootService _shootService;
        private IShootFocusService _shootFocusService;
        private IEntityViewFactory _entityViewFactory;
        private IIdentifierService _identifierService;

        public ShootFactory(IInstantiator instantiator,
            IShootService shootService,
            IShootFocusService shootFocusService,
            IIdentifierService identifierService,
            IEntityViewFactory entityViewFactory,
            ShootConfigs shootConfigs)
        {
            _identifierService = identifierService;
            _entityViewFactory = entityViewFactory;
            _shootFocusService = shootFocusService;
            _shootService = shootService;
            _instantiator = instantiator;
            _shootConfigs = shootConfigs;
        }

        public GameEntity Create(Transform parent, ShootTypeId shootTypeId)
        {
            ShootConfig config = _shootConfigs.GetById(shootTypeId);
            EntityBehaviour prefab = config.Prefab;


           GameEntity shootEntity = CreateEntity
                .Empty()
                .AddWorldPosition(Vector3.zero)
                .AddId(_identifierService.Next())
                .AddViewPrefab(prefab)
                .AddAmmoCount(config.AmmoCount)
                .PutOnAmmo()
                .AddDamage(config.DamagePerHit)
                .AddParent(parent)
                .AddShootDistance(config.ShootDistance)
                .AddLayerMask(config.Mask)
                .AddShowInputKey(config.ShowKey)
                .With(x => x.isShootingReady = true)
                .With(x => x.isShootingAvailable = true)
                .With(x => x.isShootable = true)
                .With(x => x.isAmmoAvailable = true)
                .With(x => x.isAimable = config.CanAim)
                .With(x => x.isShootAnimationFinished = true, when: !config.NeedFullAnimationPlay)
                .With(x => x.isNeedAnimationComplete = config.NeedFullAnimationPlay)
                .ReplaceLastShootTime(0)
                .AddShootInterval(config.ShootInterval)
                ;

            EntityBehaviour createdShoot = _entityViewFactory.CreateViewForEntityFromPrefab(shootEntity);
            
            createdShoot.GetComponent<OnShootAnimationPlayer>().Init(config);
            
            _shootService.SetCurrentShoot(createdShoot.GetComponent<Shoot>());

            createdShoot.Entity.Transform.parent = parent;
            createdShoot.Entity.Transform.localPosition = config.Position;
            createdShoot.Entity.Transform.localRotation = Quaternion.Euler(config.Rotation);

            return shootEntity;
        }

        private AnimancerAnimatorPlayer SetupAnimator(Shoot createdShoot, ReloadAmmoCount reloadAmmoCount)
        {
            AnimancerAnimatorPlayer shootAnimator = createdShoot.GetComponent<AnimancerAnimatorPlayer>();

            return shootAnimator
                    .With(animator => _shootService.Animator = animator)
                    .With(animator => reloadAmmoCount.SetReloadTime(animator.GetState(AnimationTypeId.Reload).Duration),
                        when: reloadAmmoCount != null)
                ;
        }
    }
}