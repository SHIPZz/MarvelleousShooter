using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Collisions
{
        [Game] public class GroundHitCollider : IComponent { public Collider Collider; }
        
        [Game] public class GroundDepth : IComponent { public float Value; }
        
        [Game] public class GroundRadius : IComponent { public float Value; }
        
        [Game] public class GroundTouchedAngle : IComponent { public float Value; }
        
        [Game] public class GroundDetectionMask : IComponent { public LayerMask Value; }
        
        [Game] public class GroundDetectionTransform : IComponent { public Transform Value; }
        
        [Game] public class NeedGroundDetection : IComponent { }
}