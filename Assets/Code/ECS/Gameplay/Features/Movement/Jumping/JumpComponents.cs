using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Jumping
{
    [Game] public class JumpingRequested : IComponent { }
    
    [Game] public class Jumping : IComponent { }
    
    [Game] public class NoGroundTime : IComponent { public float Value; }
}