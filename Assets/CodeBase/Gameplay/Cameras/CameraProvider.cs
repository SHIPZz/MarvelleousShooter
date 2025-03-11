using Unity.Cinemachine;
using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        public Camera Camera { get;  set; }
        public Transform RecoilRotator { get; set; }

        public CinemachineImpulseSource CinemachineImpulseSource { get;  set; }
        
        public Camera WeaponCamera { get;  set; }
        
        public CinemachineCamera ShakeCamera { get;  set; }
        public CinemachineCamera RecoilCamera { get;  set; }
        
        public CinemachineMixingCamera MixingCamera { get; set; }
    }
}