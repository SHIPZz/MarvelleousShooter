using Unity.Cinemachine;
using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public interface ICameraProvider
    {
        Camera Camera { get; set; }
        
        Transform RecoilRotator { get; set; }
        
        public Camera WeaponCamera { get;  set; }
        CinemachineImpulseSource CinemachineImpulseSource { get; set; }
        CinemachineCamera ShakeCamera { get; set; }
        CinemachineCamera RecoilCamera { get; set; }
        CinemachineMixingCamera MixingCamera { get; set; }
    }
}