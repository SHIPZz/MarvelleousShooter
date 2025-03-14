using Code.Gameplay.Animations;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Visuals;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Aimers
{
    public class ShootAimer : MonoBehaviour
    {
        [SerializeField] private AnimancerAnimatorPlayer _animancer;
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

        public void Idle()
        {
            _animancer.StartAnimation(AnimationTypeId.AimIdle);
            _isAiming = true;
        }

        public void Walk() => _animancer.StartAnimation(AnimationTypeId.AimWalk);

        public void StopAim() => _isAiming = false;

        private void AimShoot() => _animancer.StartAnimation(AnimationTypeId.AimShoot);
    }
}