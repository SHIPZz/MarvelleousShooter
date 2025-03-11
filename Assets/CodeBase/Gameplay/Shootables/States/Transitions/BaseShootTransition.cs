using System;
using CodeBase.Gameplay.Heroes.Services;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.InfraStructure.States.StateMachine;
using UniRx;
using Zenject;

namespace CodeBase.Gameplay.Shootables.States.Transitions
{
    public abstract class BaseShootTransition : IInitializable, IDisposable
    {
        protected CompositeDisposable CompositeDisposable = new();
        
        [Inject] protected IShootService ShootService;
        [Inject] protected IInputService InputService;
        [Inject] protected IHeroService HeroService;
        [Inject] protected IShootStateMachine ShootStateMachine;

        public virtual void Initialize()
        {
        }

        public bool CanNoAimShoot() => !IsAiming() && !IsRunning() && Shooting();
     
        public bool CanAimShoot() => IsAiming() && Shooting();

        public bool Shooting() => InputService.IsShooting() && ShootService.IsShootingAvailable;
        
        protected bool CanShootOnAir() => !OnGround() && !IsAiming() && Shooting();

        protected bool IsRunning() => InputService.IsRunningPressed();

        public bool IsAiming() => InputService.IsAiming();
        
        protected bool NoPressedInput() => !Shooting() 
                                           && !InputService.IsAiming() 
                                           && !InputService.HasAxisInput();

        protected bool OnGround() => HeroService.IsOnGround;

        protected bool IsAimingWithoutShootInput() => IsAimingWithoutAxisInput() && !Shooting();
        
        protected bool IsAimingWithoutAxisInput() => IsAiming() && !InputService.HasAxisInput();
        protected bool IsAimingWithAxisInput() => IsAiming() && InputService.HasAxisInput();
        
        protected bool IsAirAiming() =>  !OnGround() && IsAiming() && !Shooting();
        
        public bool NoMouseButtonInput() => !Shooting() && !InputService.IsAiming();

        public bool HasMoveOnGroundInput() => InputService.HasAxisInput() && HeroService.IsOnGround;

        public virtual void Dispose() => CompositeDisposable?.Dispose();
    }
}