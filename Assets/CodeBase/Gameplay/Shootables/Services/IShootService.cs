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
        bool IsReloading { get; set; }
        
        bool Reloadable { get;  }
        
        bool IsAiming { get;  }
        
        bool SameAmmoCount { get;  }
        
        bool NoAmmo { get; }
        bool CanRunAndShooting { get; }
        bool IsShootingAvailable { get; set; }
        OnShootAnimationPlayer OnShootAnimationPlayer { get; }
        void SetCurrentShoot(Shoot shoot);
        void Reload(Action onComplete = null);
    }
}