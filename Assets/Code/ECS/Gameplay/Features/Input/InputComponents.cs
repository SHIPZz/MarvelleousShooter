using Code.Gameplay.Heroes.Enums;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Input
{
    [Input] public class ShootingPressed : IComponent {}
    
    [Input] public class AimingPressed : IComponent {}
    
    [Input] public class AimingAvailable : IComponent {}
    
    [Input] public class ShootingAvailable : IComponent {}
    
    [Input] public class ReloadAvailable : IComponent {}
    
    [Input] public class RunningPressed : IComponent {}
    
    [Input] public class ReloadingPressed : IComponent {}
    
    [Input] public class Axis : IComponent { public Vector3 Value; }
    
    [Input] public class GunChangePressed : IComponent { }
    
    [Input] public class SelectedShoot : IComponent { public GunInputTypeId Value; }
    
    [Input] public class HasAxis : IComponent { }
    
    [Input] public class Input : IComponent {}
}