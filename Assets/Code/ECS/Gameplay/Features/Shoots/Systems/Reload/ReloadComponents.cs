using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    [Game] public class Reloadable : IComponent { }
    
    [Game] public class ReloadRequested : IComponent { }
    
    [Game] public class ReloadTime : IComponent { public float Value; }
    
    [Game] public class ReloadTimeLeft : IComponent { public float Value; }
    
    [Game] public class ReloadTimeEnded : IComponent {  }
    
    [Game] public class Reloading : IComponent { }
    
    [Game] public class ReloadingFinished : IComponent { }
}