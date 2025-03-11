using Unity.Cinemachine;
using UnityEngine;

namespace CodeBase.Gameplay.Cameras
{
    public class CameraHolder: MonoBehaviour
    {
        public Camera MainCamera;
        public Camera WeaponCamera;
        public CinemachineCamera ShakeCamera;
        public CinemachineCamera RecoilCamera;
        public CinemachineMixingCamera MixingCamera;
        public CinemachineImpulseSource CinemachineImpulseSource;
        public Transform RecoilRotator;
    }
}