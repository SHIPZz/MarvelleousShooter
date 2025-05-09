
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.DoubleShoots
{
    [Game] public class DoubleShootRequested : IComponent { }
    
    [Game] public class DoubleShooting : IComponent { }
    
    [Game] public class DoubleShootingAvailable : IComponent { }
    
    [Game] public class DoubleShootingProcessing : IComponent { }
    
    [Game] public class DoubleShootingProcessed : IComponent { }
}