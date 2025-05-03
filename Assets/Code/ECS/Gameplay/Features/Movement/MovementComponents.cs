using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Movement
{
    [Game] public class Speed : IComponent { public float Value; }
    
    [Game] public class AnimationDuration : IComponent { public float Value; }
    
    [Game] public class ElapsedTime : IComponent { public float Value; }
    
    [Game] public class AnimationCurveComponent : IComponent { public AnimationCurve Value; }
    
    [Game] public class UpdateHeightBySinCurve : IComponent {  }
    
    [Game] public class HeightUpdated : IComponent {  }
    
    [Game] public class StartHeight : IComponent { public float Value; }

    [Game] public class Moving : IComponent {  }
    
    [Game] public class NoGround : IComponent {  }
    
    [Game] public class Movable : IComponent {  }
    
    [Game] public class Walking : IComponent {  }
    
    [Game] public class Idle : IComponent {  }
    
    [Game] public class OnGround : IComponent {  }
    
    [Game] public class DestructOnMovingFinished : IComponent {  }
    
    [Game] public class MovingAvailable : IComponent {  }
    
    [Game] public class RunningAvailable : IComponent {  }
    
    [Game] public class Running : IComponent {  }
    
    [Game] public class CanRun : IComponent {  }
    
    [Game] public class IdleAvailable : IComponent {  }
    
    [Game] public class MovementAnimAvailable : IComponent {  }
    
    [Game] public class RunningAnimAvailable : IComponent {  }

    [Game] public class TurnAlongDirection : IComponent {  }
    
    [Game] public class RotateAlongDirection : IComponent {  }
    
    [Game] public class EndPoint : IComponent { public Vector3 Value; }
    
    [Game] public class VerticalRotation : IComponent { public float Value; }
    
    [Game] public class InitialSpeed : IComponent { public float Value; }
    
    [Game] public class HorizontalRotation : IComponent { public float Value; }
    
    [Game] public class EndPointReached : IComponent {  }

    [Game] public class NeedRandomEndPoint : IComponent {  }
    
    [Game] public class OrbitRadius : IComponent { public float Value; }
    
    [Game] public class OrbitPhase : IComponent { public float Value; }
    
    [Game] public class OrbitCenterFollowTarget : IComponent { public int Value; }
    
    [Game] public class OrbitCenterPosition: IComponent { public Vector3 Value; }
    
}
