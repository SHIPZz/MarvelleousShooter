using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Visuals;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Aimers
{
    public class ShootAimer : MonoBehaviour
    {
        [SerializeField] private ShootAnimator _shootAnimator;
        [SerializeField] private Shoot _shoot;
        [SerializeField] private OnShootAnimationPlayer onShootAnimationPlayer;
        
        private bool _isAiming;

        [Inject] private IInputService _inputService;

        private void Start()
        {
            _shoot
                .ShootEvent
                .Where(_ => _isAiming)
                .Subscribe(_ => AimShoot()).AddTo(this);
        }

        public void Aim()
        {
            if(_isAiming)
                return;
            
            _shootAnimator.StartAim();
            _isAiming = true;
        }

        public void StopAim()
        {
            _shootAnimator.StopAim();
            _isAiming = false;
        }

        private void AimShoot() => _shootAnimator.StartAimShooting();
    }
}