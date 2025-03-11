using System.Collections.Generic;
using CodeBase.Gameplay.Input;
using CodeBase.Gameplay.Shootables.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public class OnShootAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private ShootAnimator _shootAnimator;
        [SerializeField] private Shoot _shoot;
        [SerializeField] private List<AnimationTypeId> _targetAnimations;

        [Inject] private IInputService _inputService;

        private ShootConfig _shootConfig;

        private bool _animationFinished;

        private bool _isAiming => _inputService.IsAiming();

        private void Start() => _shoot.ShootEvent.Subscribe(_ => PlayShootAnimation()).AddTo(this);

        public void Init(ShootConfig shootConfig)
        {
            _shootConfig = shootConfig;

            foreach (AnimationTypeId animationTypeId in _targetAnimations)
            {
                _shootAnimator
                    .GetState(animationTypeId)
                    .Events(this).OnEnd += SetAnimFinished;
            }
        }

        private void OnDestroy()
        {
            foreach (AnimationTypeId animationTypeId in _targetAnimations)
            {
                _shootAnimator
                    .GetState(animationTypeId)
                    .Events(this).OnEnd -= SetAnimFinished;
            }
        }

        public bool AnimationFinished() => !_shootConfig.NeedFullAnimationPlay || _animationFinished;

        private void PlayShootAnimation()
        {
            _animationFinished = false;
            
            if (!_isAiming)
                _shootAnimator.StartShooting();
            else
                _shootAnimator.StartAimShooting();
        }


        private void SetAnimFinished() => _animationFinished = true;
    }
}