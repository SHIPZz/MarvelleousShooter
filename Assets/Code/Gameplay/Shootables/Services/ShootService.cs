using System;
using System.Threading;
using Code.Gameplay.Animations;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Aimers;
using Code.Gameplay.Shootables.Configs;
using Code.Gameplay.Shootables.Recoils;
using Code.Gameplay.Shootables.Visuals;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Gameplay.Shootables.Services
{
    public class ShootService : IShootService, IDisposable
    {
        private readonly ShootConfigs _shootConfigs;
        private readonly IInputService _inputService;
        private CancellationTokenSource _cancellationToken = new();
        private ReloadAmmoCount _reloadAmmoCount;
        private Recoil _recoil;
        private int _ammoCountFromConfig;
        private AmmoCount _ammoCount;
        private ShootConfig _config;

        public ShootService(ShootConfigs shootConfigs, IInputService inputService)
        {
            _inputService = inputService;
            _shootConfigs = shootConfigs;
        }

        public Shoot CurrentShoot { get; private set; }
        
        public ShootAimer Aimer { get; private set; }

        public bool StopShootAfterAnimPlayed { get; private set; }
        public bool CanRunAndShooting { get; private set; }

        public AnimancerAnimatorPlayer Animator { get; set; }
        
        public ReloadAmmoCount ReloadAmmoCount => _reloadAmmoCount;

        public bool IsReloading { get; set; }
        
        public bool IsFocusing { get; set; }

        public bool Reloadable { get; private set; }

        public bool CanShootWithAim { get; private set; }
        
        public bool IsAiming => _inputService.IsAiming() && CanShootWithAim;

        public bool SameAmmoCount => _ammoCount.Value == _ammoCountFromConfig;

        public bool IsShooting => CurrentShoot.IsShooting;
        public bool IsShootingAvailable => CurrentShoot.IsShootingAvailable;

        public OnShootAnimationPlayer OnShootAnimationPlayer { get; private set; }
        
        public bool CanAim => _config != null && _config.CanAim;
        public bool HasIdleFocus => _config != null && _config.HasIdleFocus;
        public bool NoAmmo => _reloadAmmoCount != null && _reloadAmmoCount.NoAmmo;

        public void SetCurrentShoot(Shoot shoot)
        {
            CurrentShoot = shoot;
            Animator = shoot.GetComponent<AnimancerAnimatorPlayer>();
            Aimer = shoot.GetComponent<ShootAimer>();
            _reloadAmmoCount = shoot.GetComponent<ReloadAmmoCount>();
            _ammoCount = shoot.GetComponent<AmmoCount>();
            OnShootAnimationPlayer = shoot.GetComponent<OnShootAnimationPlayer>();
            _recoil = shoot.GetComponent<Recoil>();

             _config = _shootConfigs.GetById(shoot.Id);
            
            Reloadable = _config.Reloadable;

            if (!Reloadable)
                IsReloading = false;

            CanShootWithAim = _config.CanAim;
            CanRunAndShooting = _config.CanRunAndShoot;
            _ammoCountFromConfig = _config.AmmoCount;
            StopShootAfterAnimPlayed = _config.NeedFullAnimationPlay;
        }

        public void MarkShootingAvailable(bool isAvailable) => CurrentShoot.MarkShootingAvailable(isAvailable);

        public void Reload(Action onComplete = null) => ReloadAsync(_ammoCountFromConfig,onComplete).Forget();

        public float GetDistance() => _config.ShootDistance;

        public LayerMask GetMask() => _config.Mask;

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
                // Animator.StartReloading();
                await _reloadAmmoCount.DoAsync(_cancellationToken.Token);
                _ammoCount?.Increase(ammoCount);
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