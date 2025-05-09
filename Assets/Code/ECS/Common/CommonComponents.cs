using Code.ECS.Effects;
using Code.ECS.Gameplay.Features.Animations;
using Code.ECS.Progress;
using Code.ECS.View;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.ECS.Common
{
   [Game] public class WorldPosition : IComponent { public Vector3 Value; }
   
     [Game, Meta] public class Id : ISavedComponent {[PrimaryEntityIndex]  public int Value; }
  
  [Game] public class EntityLink : IComponent {[EntityIndex]  public int Value; }
    
   [Game] public class Direction : IComponent { public Vector3 Value; }
 
   [Game] public class TransformComponent : IComponent { public Transform Value; }
   
   [Game] public class SpriteRendererComponent : IComponent { public SpriteRenderer Value; }
   
   [Game] public class Damage : IComponent { public float Value; }
   
   [Game] public class Rotation : IComponent { public Quaternion Value; }
   
   [Game] public class InitialLocalPosition : IComponent { public Vector3 Value; }
   
   [Game] public class Parent : IComponent { public Transform Value; }
   
   [Game] public class View : IComponent { public IEntityView Value; }
    
   [Game] public class ViewPath : IComponent { public string Value; }
    
   [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }

   [Game, Meta] public class Destructed : IComponent { }
    
   [Game] public class Active : IComponent { }
    
   [Game] public class LayerMaskComponent : IComponent { public int Value; }
   
   [Game] public class AnimancerAnimator : IComponent { public AnimancerAnimatorPlayer Value; }
   
   [Game] public class EffectPlayerComponent : IComponent { public EffectPlayer Value; }
    
   [Game] public class SelfDestructTimer : IComponent { public float Value; }
}