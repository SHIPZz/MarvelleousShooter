using CodeBase.Gameplay.Cameras.Shake;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public class ShakeCameraOnAnimEnd : MonoBehaviour
    {
        [Inject] private ICameraShakeService _cameraShakeService;

        public void Shake() => _cameraShakeService.ShakeByCameraForward();
    }
}