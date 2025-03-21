using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Ammo
{
    [Game] public class AmmoCount : IComponent { public float Value; }
    
    [Game] public class AmmoAvailable : IComponent {  }
    
    [Game] public class AmmoDecreased : IComponent {  }
    
    [Game] public class AmmoCountLeft : IComponent { public float Value; }
}