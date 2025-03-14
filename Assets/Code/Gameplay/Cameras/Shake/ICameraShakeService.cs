using UnityEngine;

namespace Code.Gameplay.Cameras.Shake
{
    public interface ICameraShakeService
    {
        void Shake(float amplitude);
        void Shake(Vector3 position);
        void ShakeByCameraForward();
    }
}