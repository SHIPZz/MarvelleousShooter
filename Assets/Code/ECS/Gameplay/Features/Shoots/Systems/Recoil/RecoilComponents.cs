using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Recoil
{
    [Game] public class HasRecoil : IComponent {}
    
    [Game] public class RecoilPatternIndex : IComponent { public int Value; }
    
    [Game] public class RecoilRecovering : IComponent {}
    
    [Game] public class Patterns : IComponent  { public Vector2[] Value; }
    
    [Game] public class RecoilDuration : IComponent   { public float Value; }
    
    [Game] public class RecoilDurationLeft : IComponent   { public float Value; }
    
    [Game] public class RecoilDurationUp : IComponent   { }
    
    [Game] public class HorizontalRecoil : IComponent  { public float Value; }
    
    [Game] public class RecoilRotator : IComponent  { public Transform Value; }
    
    [Game] public class AimMultiplier : IComponent  { public float Value; }
    
    [Game] public class JumpMultiplier : IComponent  { public float Value; }
    
    [Game] public class VerticalRecoil : IComponent  { public float Value; }
    
    [Game] public class TotalVerticalRecoil : IComponent  { public float Value; }
    
    [Game] public class TotalHorizontalRecoil : IComponent  { public float Value; }
    
    [Game] public class MinHorizontalRecoilOnJump : IComponent  { public float Value; }
    
    [Game] public class MinVerticalRecoilOnJump : IComponent  { public float Value; }
    
    [Game] public class MaxHorizontalRecoilOnJump : IComponent  { public float Value; }

    [Game] public class CameraRecoilSmoothing : IComponent { public float Value; }
    
    [Game] public class CurrentCameraRotation : IComponent { public Vector3 Value; }
    
    [Game] public class TargetCameraRotation : IComponent { public Vector3 Value; }
    
    [Game] public class RecoilRecoverySpeed : IComponent { public float Value; }
}