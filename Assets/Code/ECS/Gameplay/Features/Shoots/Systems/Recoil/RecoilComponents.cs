using Code.Gameplay.Shootables.Recoils;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    [Game] public class HasRecoil : IComponent {}
    
    [Game] public class RecoilProgress : IComponent { public float Value; }
    
    [Game] public class RecoilPatternIndex : IComponent { public int Value; }
    
    [Game] public class Patterns : IComponent  { public Vector2[] Value; }
    
    [Game] public class RecoilSpeed : IComponent   { public float Value; }
    
    [Game] public class CurrentRecoil : IComponent   { public Vector3 Value; }
    
    [Game] public class RecoilRotation : IComponent   { public Quaternion Value; }
    
    [Game] public class TargetRecoil : IComponent   { public Vector3 Value; }
    
    [Game] public class HorizontalRecoil : IComponent  { public float Value; }
    
    [Game] public class RecoilDataComponent : IComponent  { public RecoilData Value; }
    
    [Game] public class AimMultiplier : IComponent  { public float Value; }
    
    [Game] public class JumpMultiplier : IComponent  { public float Value; }
    
    [Game] public class VerticalRecoil : IComponent  { public float Value; }
    
    [Game] public class AimJumpMultiplier : IComponent  { public float Value; }
    
    [Game] public class TotalVerticalRecoil : IComponent  { public float Value; }
    
    [Game] public class TotalHorizontalRecoil : IComponent  { public float Value; }
    
    [Game] public class MinHorizontalRecoilOnJump : IComponent  { public float Value; }
    
    [Game] public class MinVerticalRecoilOnJump : IComponent  { public float Value; }
    
    [Game] public class MaxHorizontalRecoilOnJump : IComponent  { public float Value; }

    [Game] public class RecoilRecoverySpeed : IComponent { public float Value; }
}