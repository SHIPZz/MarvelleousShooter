using System;
using System.Collections.Generic;
using Code.Gameplay.Animations;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Configs;
using Code.Gameplay.Shootables.Visuals;
using UniRx;
using Zenject;

namespace Code.Gameplay.Shootables.Services
{
    public interface IShootFocusService
    {
        bool IsFocusing { get; }
        IObservable<Unit> Started { get; }
        IObservable<Unit> Stopped { get; }
        void StopFocusing();
        bool CurrentGunHasFocus();
        void AddFocusGun(Shoot targetShoot);
    }

    public class ShootFocusService : IInitializable, IDisposable, IShootFocusService
    {
        private readonly Subject<Unit> _started = new();
        private readonly Subject<Unit> _stopped = new();
        private readonly CompositeDisposable _compositeDisposable = new();

        private readonly IInputService _inputService;
        private readonly ShootConfigs _shootConfigs;
        private readonly IShootService _shootService;
        private readonly List<Shoot> _focusGuns = new();

        public ShootFocusService(IInputService inputService,
            ShootConfigs shootConfigs,
            IShootService shootService)
        {
            _shootService = shootService;
            _inputService = inputService;
            _shootConfigs = shootConfigs;
        }

        public bool IsFocusing { get; private set; }

        public IObservable<Unit> Started => _started;

        public IObservable<Unit> Stopped => _stopped;

        public void Initialize()
        {
            _inputService
                .OnGunFocusRequested
                .Subscribe(_ =>
                {
                    IsFocusing = true;
                    _started?.OnNext(default);
                })
                .AddTo(_compositeDisposable);
        }

        public void AddFocusGun(Shoot targetShoot)
        {
            _focusGuns.Add(targetShoot);

            foreach (Shoot shoot in _focusGuns)
            {
                shoot.ShootAnimator.GetState(AnimationTypeId.IdleFocus).Events(this).OnEnd += StopFocusing;
            }
        }

        public bool CurrentGunHasFocus() => _shootConfigs.GetById(_shootService.CurrentShoot.Id).HasIdleFocus; 

        public void StopFocusing()
        {
            IsFocusing = false;
            _stopped?.OnNext(default);
        }

        public void Dispose()
        {
            foreach (Shoot shoot in _focusGuns)
            {
                shoot.ShootAnimator.GetState(AnimationTypeId.IdleFocus).Events(this).OnEnd -= StopFocusing;
            }
            
            _compositeDisposable?.Dispose();
            _started?.Dispose();
            _stopped?.Dispose();
        }
    }
}