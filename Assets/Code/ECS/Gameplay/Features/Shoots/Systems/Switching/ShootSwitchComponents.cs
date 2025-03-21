using Code.Gameplay.Heroes.Enums;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching
{
    [Game] public class ShootSwitchingRequested : IComponent { }
    
    [Game] public class Switchable : IComponent { }
    
    [Game] public class Switching : IComponent { }
    
    [Game] public class HeroSwitchable : IComponent { }
    
    [Game] public class HidingStarted : IComponent { }
    
    [Game] public class ShowingStarted : IComponent { }
    
    [Game] public class TargetSwitchGunId : IComponent { public int Value; }
    
    [Game] public class PreviousSwitchedGunId : IComponent { public int Value; }
    
    [Game] public class PreviousGunHidden : IComponent {  }
    
    [Game] public class TargetGunShown : IComponent {  }
    
    [Game] public class ShootSwitchingAvailable : IComponent { }
    
    [Game] public class ShootSwitchingReady : IComponent { }
}