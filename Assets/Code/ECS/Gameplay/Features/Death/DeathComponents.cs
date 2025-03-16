using Entitas;

namespace Code.ECS.Gameplay.Features.Death
{
    [Game] public class Dead : IComponent { }
    
    [Game] public class DeathProcessing : IComponent { }
    
    [Game] public class DeathAnimationDuration : IComponent { public float Value; }
}