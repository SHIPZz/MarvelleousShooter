using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.TargetCollection
{
    [Game] public class TargetsBuffer : IComponent { public List<int> Value; }
    
    [Game] public class ProcessedTargetsBuffer : IComponent { public List<int> Value; }
    
    [Game] public class CollectTargetsInterval : IComponent { public float Value; }
    
    [Game] public class CastFromTargetTransform : IComponent { public Transform Value; }
    
    [Game] public class CastDirection : IComponent { public Vector3 Value; }
    
    [Game] public class CastDistance : IComponent { public float Value; }
    
    [Game] public class CollectTargetsTimer : IComponent { public float Value; }
    
    [Game] public class Radius : IComponent { public float Value; }
    
    [Game] public class ReadyToCollectTargets : IComponent {  }
    
    [Game] public class CastFromCamera : IComponent {  }
    
    [Game] public class HitDetected : IComponent {  }
    
    [Game] public class OnAnimationEndCast : IComponent {  }
    
    [Game] public class OnAnimationEndCastRequested : IComponent {  }
    
    [Game] public class CastFromStartPosition : IComponent {  }
    
    [Game] public class CollectingAvailable : IComponent {  }
    
    [Game] public class Reached : IComponent {  }
    
    [Game] public class ReadyToCollectOnMovingFinished : IComponent {  }
    
    [Game] public class Ignored : IComponent {  }
    
    [Game] public class OverflowProcessedTargetsBuffer : IComponent {  }
    
    [Game] public class TargetLimit : IComponent { public int Value; }
    
    [Game] public class CollectTargetsLayerMask : IComponent { public int Value; }
    
    [Game] public class LastCollectedId : IComponent { public int Value; }
    
    [Game] public class IgnoreBuffer : IComponent { public List<int> Value; }
    
    [Game] public class CollectingTargetsContinuously : IComponent {  }
}