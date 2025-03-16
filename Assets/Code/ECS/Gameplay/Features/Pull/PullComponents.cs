using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Statuses;
using Entitas;

namespace Code.ECS.Gameplay.Features.Pull
{
    [Game] public class PullTargetList : IComponent { public List<int> Value; }
    
    [Game] public class PullTargetHolderStatuses : IComponent { public List<StatusSetup> Value; }
    
    [Game] public class PullTargetHolder : IComponent {  }
    
    [Game] public class PullTargetConsistently : IComponent {  }

    [Game] public class PullingDetector : IComponent {  }
    
    [Game] public class PullAnchorTargetId : IComponent { public int Value; }
    
    [Game] public class PullProducerId : IComponent { public int Value; }
    
    [Game] public class DestructOnMaxPullTargetReached : IComponent {  }
    
    [Game] public class MaxPullTargetHold : IComponent {  public int Value; }
    
    [Game] public class PullTargetLayerMask : IComponent {  public int Value; }
    
    [Game] public class PullInRadius : IComponent {  public float Value; }
    
    [Game] public class MinCountToPullTargets : IComponent {  public int Value; }
    
}