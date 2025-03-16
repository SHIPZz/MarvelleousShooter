using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection
{
    [Game] public class TargetsBuffer : IComponent { public List<int> Value; }
    
    [Game] public class ProcessedTargetsBuffer : IComponent { public List<int> Value; }
    
    [Game] public class CollectTargetsInterval : IComponent { public float Value; }
    
    [Game] public class CollectTargetsTimer : IComponent { public float Value; }
    
    [Game] public class Radius : IComponent { public float Value; }
    
    [Game] public class ReadyToCollectTargets : IComponent {  }
    
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