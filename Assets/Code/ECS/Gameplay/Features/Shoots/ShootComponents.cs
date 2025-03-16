using System.Collections.Generic;
using Code.Gameplay.Effects;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Shootables;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots
{
    [Game] public class Shootable : IComponent { }
    
    [Game] public class Shooting : IComponent { }
    
    [Game] public class ShootingContinuously : IComponent { }
    
    [Game] public class CanRunAndShoot : IComponent { }
    
    [Game] public class ShootingRequested : IComponent { }
    
    [Game] public class NeedAnimationComplete : IComponent { }
    
    [Game] public class ShootingAvailable : IComponent { }
    
    [Game] public class ShootingReady : IComponent { }
    
    [Game] public class Reloadable : IComponent { }
    
    [Game] public class ReloadRequested : IComponent { }
    
    [Game] public class ReloadTime : IComponent { public float Value; }
    
    [Game] public class ReloadTimeLeft : IComponent { public float Value; }
    
    [Game] public class ReloadTimeEnded : IComponent {  }
    
    [Game] public class Reloading : IComponent { }
    
    [Game] public class ReloadingFinished : IComponent { }
    
    [Game] public class Aimable : IComponent { }
    
    [Game] public class AimingRequested : IComponent { }
    
    [Game] public class Aiming : IComponent { }
    
    [Game] public class AimingAvailable : IComponent { }
    
    [Game] public class ShootHolder : IComponent { }
    
    [Game] public class ShootAnimationFinished : IComponent { }
    
    [Game] public class GunHasFocus : IComponent { }
    
    [Game] public class AvailableShoots : IComponent { public List<ShootTypeId> Value; }
    
    [Game] public class Hits : IComponent { public RaycastHit[] Value; }
    
    [Game] public class ShootInterval : IComponent { public float Value; }
    
    [Game] public class CurrentShootTypeId : IComponent { public ShootTypeId Value; }
    
    [Game] public class HitEffectTypeId : IComponent { public EffectTypeId Value; }
    
    [Game] public class ShootDistance : IComponent { public float Value; }
    
    [Game] public class LastShootTime : IComponent { public float Value; }
    
    [Game] public class AmmoCount : IComponent { public float Value; }
    
    [Game] public class AmmoAvailable : IComponent {  }
    
    [Game] public class AmmoDecreased : IComponent {  }
    
    [Game] public class AmmoCountLeft : IComponent { public float Value; }
    
    [Game] public class ShootTypeIdComponent : IComponent { public ShootTypeId Value; }
    
    [Game] public class ShowInputKeyComponent : IComponent { public ShootInputTypeId Value; }
}