using Entitas;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    [Game] public class CurrentHp : IComponent { public float Value; }
    
    [Game] public class MaxHp : IComponent { public float Value; }
    
    [Game] public class Alive : IComponent { }
    
    [Game] public class RestoreHp : IComponent { public float Value; }
    
    [Game] public class HpRestored : IComponent { }
}
