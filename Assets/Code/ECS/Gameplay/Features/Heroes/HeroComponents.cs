using Entitas;
using KinematicCharacterController.Examples;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Heroes
{
    [Game] public class Hero : IComponent { }
    
    [Game] public class ConnectedWithHero : IComponent { }
    
    [Game] public class HeroAction : IComponent { }
    
    [Game] public class HeroGun : IComponent { }
    
    [Game] public class CurrentGunId : IComponent { public int Value; }
    
    [Game] public class CharacterControllerComponent : IComponent { public CharacterController Value; }
}