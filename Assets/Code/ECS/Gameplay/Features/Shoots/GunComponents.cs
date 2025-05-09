using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using DG.Tweening;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots
{
    [Game] public class GunComponent : IComponent { }
    
    [Game] public class Shooting : IComponent { }
    
    [Game] public class ShootingContinuously : IComponent { }
    
    [Game] public class CanRunAndShoot : IComponent { }
    
    [Game] public class ShootingRequested : IComponent { }
    
    [Game] public class ShootingStarted : IComponent { }
    
    [Game] public class ShootingAvailable : IComponent { }
    
    [Game] public class CanRaycast : IComponent { }
    
    [Game] public class ShootWithoutAmmo : IComponent { }
    
    [Game] public class GunHolder : IComponent { }

    [Game] public class GunHasFocus : IComponent { }

    [Game] public class AvailableGuns : IComponent { public List<GunTypeId> Value; }

    [Game] public class Hits : IComponent { public List<RaycastHit> Value; }

    [Game] public class OwnerId : IComponent { public int Value; }
    
    [Game] public class CurrentGunTypeId : IComponent { public GunTypeId Value; }

    [Game] public class HitEffectTypeId : IComponent { public EffectTypeId Value; }

    [Game] public class ShootDistance : IComponent { public float Value; }

    [Game] public class MoveGunPosition : IComponent { public Vector3 Value; }
    
    [Game] public class MoveGunDuration : IComponent { public float Value; }
    
    [Game] public class MoveRecoilTween : IComponent { public Tween Value; }

    [Game] public class ShootCooldown : IComponent { public float Value; }

    [Game] public class ShootCooldownLeft : IComponent { public float Value; }
    
    [Game] public class ShootCooldownUp : IComponent {  }
    
    [Game] public class EmptyGun : IComponent {  }
    
    [Game] public class GunTypeIdComponent : IComponent { public GunTypeId Value; }
    
    [Game] public class GunInputKeyComponent : IComponent { public GunInputTypeId Value; }
}