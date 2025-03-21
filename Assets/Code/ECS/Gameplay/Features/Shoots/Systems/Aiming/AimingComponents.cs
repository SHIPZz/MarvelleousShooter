using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Aiming
{
    [Game] public class Aimable : IComponent { }
    
    [Game] public class NotAimable : IComponent { }
    
    [Game] public class AimingRequested : IComponent { }
    
    [Game] public class Aiming : IComponent { }
    
    [Game] public class AimingAvailable : IComponent { }
}