using Code.Gameplay.Cameras.Shake;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Visuals
{
    public class ShakeCameraOnShoot : MonoBehaviour
    {
        [SerializeField] private Shoot _shoot;
        
        [Inject] private ICameraShakeService _cameraShakeService;

        private void Start()
        {
            _shoot
                .ShootEvent
                .Subscribe(_ => _cameraShakeService.ShakeByCameraForward())
                .AddTo(this);
        }
    }
}