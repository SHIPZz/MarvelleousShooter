using UnityEngine;

namespace Code.Gameplay.Cameras.Shake
{
    public class CameraShakeService : ICameraShakeService
    {
        private readonly ICameraProvider _cameraProvider;
        
        public CameraShakeService(ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
        }
        
        public void Shake(float amplitude)
        {
            _cameraProvider.CinemachineImpulseSource.GenerateImpulseWithForce(amplitude);
        }
        
        public void Shake(Vector3 position)
        {
            _cameraProvider.CinemachineImpulseSource.GenerateImpulseWithVelocity(position);
        }
        
        public void ShakeByCameraForward()
        {
            _cameraProvider.CinemachineImpulseSource.GenerateImpulseWithVelocity(_cameraProvider.Camera.transform.forward);
        }
        
    }
}