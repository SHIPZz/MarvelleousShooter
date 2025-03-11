using UnityEngine;

namespace CodeBase.Gameplay.Cameras.Shake
{
    public interface ICameraShakeService
    {
        void Shake(float amplitude);
        void Shake(Vector3 position);
        void ShakeByCameraForward();
    }
}