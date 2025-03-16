using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.ECS.Gameplay.Features.Statuses
{
    [Game] public class Status : IComponent { }

    [Game] public class Poison : IComponent { }
    
    [Game] public class Freeze : IComponent { }
    
    [Game] public class Vampirism : IComponent { }

    [Game] public class SpeedUp : IComponent { }
    
    [Game] public class PeriodicDamageStatus : IComponent { }
    
    [Game] public class Invulnerable : IComponent { }
    
    [Game] public class InvulnerableStatus : IComponent { }
    
    [Game] public class MaxHpIncrease : IComponent { }
    
    [Game] public class CurrentHpStatus : IComponent { }
    
    [Game] public class ScaleIncrease : IComponent { }
    
    [Game] public class StatusCreator : IComponent { }
    
    [Game] public class StatusTypeIdComponent : IComponent { public StatusTypeId Value; }

    [Game] public class Applied : IComponent { }

    [Game] public class Unapplied : IComponent { }

    [Game] public class Affected : IComponent { }
    
    [Game] public class Duration : IComponent { public float Value; }
    
    [Game] public class ApplierStatusLink : IComponent { [EntityIndex] public int Value; }
    
    [Game] public class TimeLeft : IComponent { public float Value; }
    
    [Game] public class Period : IComponent { public float Value; }
    
    [Game] public class TimeSinceLastTick : IComponent { public float Value; }
    
    [Game] public class StatusSetupsComponent : IComponent { public List<StatusSetup> Value; }
}