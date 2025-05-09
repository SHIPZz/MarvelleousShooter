using Entitas;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    [Game] public class CurrentHp : IComponent { public float Value; }
    
    [Game] public class MaxHp : IComponent { public float Value; }
    
    [Game] public class Alive : IComponent { }
    
    [Game] public class RestoreHp : IComponent { public float Value; }
    
    [Game] public class HpRestored : IComponent { }
    
    [Game] public class Dead : IComponent { }
    
    [Game] public class DeathProcessing : IComponent { }
    
    [Game] public class DeathAnimationDuration : IComponent { public float Value; }
}
