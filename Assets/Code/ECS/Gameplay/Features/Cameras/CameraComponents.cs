using Code.Gameplay.Cameras;
using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Cameras
{
    [Game] public class CameraHolderComponent : IComponent { public CameraHolder Value; }
    
    [Game] public class MainCameraComponent : IComponent { public Camera Value; }
    
    [Game] public class CameraRotationSharpnessComponent : IComponent { public float Value; }
    
    [Game] public class MinCameraRotation : IComponent { public float Value; }
    
    [Game] public class MaxCameraRotation : IComponent { public float Value; }
    
    [Game] public class CurrentCameraRotation : IComponent { public Quaternion Value; }
    
    [Game] public class BaseCameraRotation : IComponent { public Quaternion Value; }
    
    [Game] public class FinalCameraRotation : IComponent { public Quaternion Value; }
    
    [Game] public class FinalRecoilRotation : IComponent { public Quaternion Value; }
    
    [Game] public class CameraRotationSpeed : IComponent { public float Value; }
}