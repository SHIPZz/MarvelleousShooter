using System.Collections.Generic;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Shootables;
using Code.Gameplay.Shootables.Visuals;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots
{
    [Game] public class Shootable : IComponent { }
    
    [Game] public class Shooting : IComponent { }
    
    [Game] public class ShootingRequested : IComponent { }
    
    [Game] public class NeedAnimationComplete : IComponent { }
    
    [Game] public class ShootingAvailable : IComponent { }
    
    [Game] public class ShootingReady : IComponent { }
    
    [Game] public class Reloadable : IComponent { }
    
    [Game] public class Aimable : IComponent { }
    
    [Game] public class AimingRequested : IComponent { }
    
    [Game] public class Aiming : IComponent { }
    
    [Game] public class Reloading : IComponent { }
    
    [Game] public class ShootHolder : IComponent { }
    
    [Game] public class ShootAnimationFinished : IComponent { }
    
    [Game] public class GunHasFocus : IComponent { }
    
    [Game] public class AvailableShoots : IComponent { public List<ShootTypeId> Value; }
    
    [Game] public class ShootInterval : IComponent { public float Value; }
    
    [Game] public class CurrentShootTypeId : IComponent { public ShootTypeId Value; }
    
    [Game] public class ShootDistance : IComponent { public float Value; }
    
    [Game] public class LastShootTime : IComponent { public float Value; }
    
    [Game] public class AmmoCount : IComponent { public float Value; }
    
    [Game] public class AmmoAvailable : IComponent {  }
    
    [Game] public class AmmoCountCurrent : IComponent { public float Value; }
    
    [Game] public class AmmoCountLeft : IComponent { public float Value; }
    
    [Game] public class ShootTypeIdComponent : IComponent { public ShootTypeId Value; }
    
    [Game] public class ShowInputKeyComponent : IComponent { public ShootInputTypeId Value; }
}