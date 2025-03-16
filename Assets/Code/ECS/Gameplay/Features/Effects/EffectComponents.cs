using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Effects
{
    [Game] public class Effect : IComponent { }
    
    [Game] public class Processed : IComponent { }
    
    [Game] public class HealEffect : IComponent { }

    [Game] public class ApplyEffectOnEndPointReached : IComponent {  }
    
    [Game] public class ApplyStatusOnEndPointReached : IComponent {  }
    
    [Game] public class PullEffect : IComponent { }
    
    [Game] public class DamageEffect : IComponent { }

    [Game] public class EffectValue : IComponent { public float Value; }
    
    [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }

    [Game] public class TargetId : IComponent { public int Value; }
    
    [Game] public class ProducerId : IComponent { public int Value; }
    
    [Game] public class EffectTypeIdComponent : IComponent { public EffectTypeId Value; }
}