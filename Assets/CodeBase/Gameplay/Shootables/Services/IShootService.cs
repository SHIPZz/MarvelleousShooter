using System;
using CodeBase.Gameplay.Shootables.Aimers;
using CodeBase.Gameplay.Shootables.Visuals;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Services
{
    public interface IShootService
    {
        Shoot CurrentShoot { get;  }
        ShootAimer Aimer { get;  }
        ShootAnimator Animator { get; set; }
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