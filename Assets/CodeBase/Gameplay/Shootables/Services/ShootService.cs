using System;
using System.Threading;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Aimers;
using CodeBase.Gameplay.Shootables.Configs;
using CodeBase.Gameplay.Shootables.Recoils;
using CodeBase.Gameplay.Shootables.Visuals;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Services
{
    public class ShootService : IShootService, IDisposable
    {
        private CancellationTokenSource _cancellationToken = new();
        private readonly ShootConfigs _shootConfigs;
        private ReloadAmmoCount _reloadAmmoCount;
        private Recoil _recoil;
        private int _ammoCountFromConfig;
        private IInputService _inputService;

        public ShootService(ShootConfigs shootConfigs, IInputService inputService)
        {
            _inputService = inputService;
            _shootConfigs = shootConfigs;
        }

        public Shoot CurrentShoot { get; private set; }
        
        public ShootAimer Aimer { get; private set; }

        public bool StopShootAfterAnimPlayed { get; private set; }
        public bool CanRunAndShooting { get; private set; }

        public bool IsPlayingAnimation(AnimationTypeId animationTypeId) => Animator.IsPlaying(animationTypeId);

        public ShootAnimator Animator { get; set; }

        public bool IsReloading { get; set; }

        public bool Reloadable { get; private set; }

        public bool CanShootWithAim { get; private set; }
        
        public bool IsAiming => _inputService.IsAiming() && CanShootWithAim;

        public bool SameAmmoCount => AmmoCount.Value == _ammoCountFromConfig;

        public bool IsShootingAvailable { get; set; }
        
        public OnShootAnimationPlayer OnShootAnimationPlayer { get; private set; }

        public AmmoCount AmmoCount { get; private set; }

        public bool NoAmmo => _reloadAmmoCount != null && _reloadAmmoCount.NoAmmo;

        public void SetCurrentShoot(Shoot shoot)
        {
            CurrentShoot = shoot;
            Animator = shoot.GetComponent<ShootAnimator>();
            Aimer = shoot.GetComponent<ShootAimer>();
            _reloadAmmoCount = shoot.GetComponent<ReloadAmmoCount>();
            AmmoCount = shoot.GetComponent<AmmoCount>();
            OnShootAnimationPlayer = shoot.GetComponent<OnShootAnimationPlayer>();
            _recoil = shoot.GetComponent<Recoil>();

            ShootConfig shootConfig = _shootConfigs.GetById(shoot.Id);
            Reloadable = shootConfig.Reloadable;

            if (!Reloadable)
                IsReloading = false;

            CanShootWithAim = shootConfig.CanShotWithAim;
            CanRunAndShooting = shootConfig.CanRunAndShoot;
            _ammoCountFromConfig = shootConfig.AmmoCount;
            StopShootAfterAnimPlayed = shootConfig.NeedFullAnimationPlay;
        }

        public void Reload(Action onComplete = null)
        {
            ReloadAsync(_ammoCountFromConfig,onComplete).Forget();
        }

        public void StopReloading()
        {
            if (!_cancellationToken.IsCancellationRequested)
                _cancellationToken?.Cancel();

            _cancellationToken?.Dispose();
        }

        public float GetDistance()
        {
            return _shootConfigs.GetById(CurrentShoot.Id).ShootDistance;
        }

        public LayerMask GetMask()
        {
            return _shootConfigs.GetById(CurrentShoot.Id).Mask;
        }

        private async UniTaskVoid ReloadAsync(int ammoCount, Action onComplete = null)
        {
            if (!Reloadable)
                return;

            if (_reloadAmmoCount.Reloading)
                return;

            if (_cancellationToken == null || _cancellationToken.IsCancellationRequested)
            {
                _cancellationToken = new CancellationTokenSource();
            }

            _recoil.ResetRecoil();
            IsReloading = true;
            
            try
            {
                Animator.StartReloading();
                await _reloadAmmoCount.DoAsync(_cancellationToken.Token);
                Animator.StopReloading();
                AmmoCount?.Increase(ammoCount);
                IsReloading = false;
                onComplete?.Invoke();
            }
            catch (Exception e) { }
        }

        public void Dispose()
        {
            _cancellationToken?.Cancel();
            _cancellationToken?.Dispose();
        }
    }
}