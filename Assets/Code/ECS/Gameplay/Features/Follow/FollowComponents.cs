using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Follow
{
    [Game] public class FollowTargetId : IComponent { public int Value; }
    
    [Game] public class LastFollowTargets : IComponent { public List<int> Value; }
    
    [Game] public class FollowingUp : IComponent { }
    
    [Game] public class FollowNewCloseTarget : IComponent { }
    
    [Game] public class FollowDistanceLeft : IComponent { public float Value; }
    
    [Game] public class FollowMaxDistance : IComponent { public float Value; }
    
}