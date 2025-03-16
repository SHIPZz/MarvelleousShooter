using Entitas;

namespace Code.ECS.Gameplay.Features.Cooldown
{
    [Game] public class Cooldown : IComponent { public float Value; }
    
    [Game] public class CooldownLeft : IComponent { public float Value; }
    
    [Game] public class CooldownUp : IComponent {  }
}