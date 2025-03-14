using System;
using Code.Gameplay.Animations;
using Code.Gameplay.Shootables.Aimers;
using Code.Gameplay.Shootables.Visuals;

namespace Code.Gameplay.Shootables.Services
{
    public interface IShootService
    {
        Shoot CurrentShoot { get;  }
        ShootAimer Aimer { get;  }
        AnimancerAnimatorPlayer Animator { get; set; }
        ReloadAmmoCount ReloadAmmoCount { get; }
        bool IsReloading { get; set; }
        
        bool Reloadable { get;  }
        
        bool IsAiming { get;  }
        
        bool SameAmmoCount { get;  }
        
        bool NoAmmo { get; }
        bool CanRunAndShooting { get; }
        bool IsShooting { get; }
        bool IsShootingAvailable { get; }
        OnShootAnimationPlayer OnShootAnimationPlayer { get; }
        bool CanAim { get; }
        bool HasIdleFocus { get; }
        bool IsFocusing { get; set; }
        void SetCurrentShoot(Shoot shoot);
        void Reload(Action onComplete = null);
        void MarkShootingAvailable(bool isAvailable);
    }
}