using Code.ECS.Gameplay.Features.Shoots.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching
{
    [Game] public class GunSwitchingRequested : IComponent { }
    
    [Game] public class Switchable : IComponent { }
    
    [Game] public class SameGunSelected : IComponent { }
    
    [Game] public class HidingProcessing : IComponent { }
    
    [Game] public class HidingProcessed : IComponent { }
    
    [Game] public class ShowingProcessing : IComponent { }
    
    [Game] public class ShowingProcessed : IComponent { }
    
    [Game] public class SwitchingProcessing : IComponent { }
    
    [Game] public class SwitchingProcessed : IComponent { }
    
    [Game] public class HeroSwitchable : IComponent { }
    
    [Game] public class SwitchingStarted : IComponent { }
    
    [Game] public class TargetSwitchGunId : IComponent { public int Value; }
    
    [Game] public class RequestedSwitchingGun : IComponent { public GunInputTypeId Value; }
    
    [Game] public class GunSwitchingAvailable : IComponent { }
    
    [Game] public class GunSwitchingReady : IComponent { }
}