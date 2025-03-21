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
    
    [Game] public class ShootingStarted : IComponent { }
    
    [Game] public class NeedAnimationComplete : IComponent { }
    
    [Game] public class ShootingAvailable : IComponent { }
    
    [Game] public class ShootingReady : IComponent { }
    
    [Game] public class CanRaycast : IComponent { }
    
    [Game] public class ShootWithoutAmmo : IComponent { }
    
    [Game] public class ShootHolder : IComponent { }
    
    [Game] public class ShootAnimationFinished : IComponent { }
    
    [Game] public class GunHasFocus : IComponent { }
    
    [Game] public class AvailableShoots : IComponent { public List<ShootTypeId> Value; }
    
    [Game] public class Hits : IComponent { public RaycastHit[] Value; }
    
    [Game] public class ShootInterval : IComponent { public float Value; }
    
    [Game] public class OwnerId : IComponent { public int Value; }
    
    [Game] public class CurrentShootTypeId : IComponent { public ShootTypeId Value; }
    
    [Game] public class HitEffectTypeId : IComponent { public EffectTypeId Value; }
    
    [Game] public class ShootDistance : IComponent { public float Value; }
    
    [Game] public class LastShootTime : IComponent { public float Value; }
    
    [Game] public class ShootTypeIdComponent : IComponent { public ShootTypeId Value; }
    
    [Game] public class GunInputKeyComponent : IComponent { public GunInputTypeId Value; }
}