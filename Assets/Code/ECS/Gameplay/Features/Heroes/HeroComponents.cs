using ECM.Components;
using Entitas;

namespace Code.ECS.Gameplay.Features.Heroes
{
    [Game] public class Hero : IComponent { }
    
    [Game] public class HeroGun : IComponent { }
    
    [Game] public class CurrentGunId : IComponent { public int Value; }
    
    [Game] public class CharacterMovementComponent : IComponent { public CharacterMovement Value; }
}