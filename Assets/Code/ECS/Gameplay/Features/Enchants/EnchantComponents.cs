﻿using Code.ECS.Gameplay.Features.Enchants.Behaviours;
using Entitas;

namespace Code.ECS.Gameplay.Features.Enchants
{
    [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
    
    [Game] public class PoisonEnchant : IComponent {  }
    
    [Game] public class ExplosiveEnchant : IComponent {  }
    
    [Game] public class HexEnchant : IComponent {  }
 
    // [Game] public class EnchantVisualsComponent : IComponent { public IEnchantVisuals Value; }
    
    [Game] public class EnchantHolderComponent : IComponent { public EnchantHolder Value; }
}