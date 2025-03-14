using Code.Gameplay.Cameras.Shake;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Visuals
{
    public class ShakeCameraOnAnimEnd : MonoBehaviour
    {
        [Inject] private ICameraShakeService _cameraShakeService;

        public void Shake() => _cameraShakeService.ShakeByCameraForward();
    }
}