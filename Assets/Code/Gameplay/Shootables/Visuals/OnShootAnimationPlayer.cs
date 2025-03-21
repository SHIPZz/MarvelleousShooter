using System.Collections.Generic;
using Code.ECS.View;
using Code.Gameplay.Animations;
using Code.Gameplay.Input;
using Code.Gameplay.Shootables.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Visuals
{
    public class OnShootAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private AnimancerAnimatorPlayer _animancer;
        [SerializeField] private List<AnimationTypeId> _targetAnimations;
        [SerializeField] private EntityBehaviour _entityBehaviour;

        [Inject] private IInputService _inputService;

        private ShootConfig _shootConfig;

        private bool _animationFinished;

        private bool _isAiming => _inputService.IsAiming();

        public void Init(ShootConfig shootConfig)
        {
            _shootConfig = shootConfig;

            foreach (AnimationTypeId animationTypeId in _targetAnimations)
            {
                _animancer
                    .GetState(animationTypeId)
                    .Events(this).OnEnd += SetAnimFinished;
            }

            _animancer.AnimationRequested.Subscribe(id => SetAnimFinished(id)).AddTo(this);
        }

        private void SetAnimFinished(AnimationTypeId id)
        {
            if(_targetAnimations.Contains(id))
                return;
            
            SetAnimFinished();
        }

        private void OnDestroy()
        {
            foreach (AnimationTypeId animationTypeId in _targetAnimations)
            {
                _animancer
                    .GetState(animationTypeId)
                    .Events(this).OnEnd -= SetAnimFinished;
            }
        }

        public bool AnimationFinished() => !_shootConfig.NeedFullAnimationPlay || _animationFinished;

        private void PlayShootAnimation()
        {
            _animationFinished = false;

            _animancer.StartAnimation(!_isAiming ? AnimationTypeId.Shoot : AnimationTypeId.AimShoot);
        }


        private void SetAnimFinished()
        {
            // _entityBehaviour.Entity.isShootAnimationFinished = true;
        }
    }
}