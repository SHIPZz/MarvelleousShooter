using System;
using CodeBase.Gameplay.Common.Time;
using CodeBase.Gameplay.Shootables.Services;
using CodeBase.Gameplay.Shootables.Visuals;
using ECM.Components;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Heroes
{
    public class HeroMovement : MonoBehaviour
    {
        private float RunningAnimSpeed = 1;
        private float WalkingAnimSpeed = 0.5f;

        [Inject] private IShootService _shootService;
        [Inject] private ITimeService _timeService;

        [SerializeField] private float _animateSpeed = 8f;
        [SerializeField] private CharacterMovement _characterMovement;

        private ShootAnimator _shootAnimator => _shootService.Animator;
        private float _animatorSpeed;
        private float _targetAnimatorSpeed;

        private void Update()
        {
            _animatorSpeed = Mathf.Lerp(_animatorSpeed, _targetAnimatorSpeed, _animateSpeed * _timeService.DeltaTime);
            _shootAnimator.SetMoveSpeed(_animatorSpeed);
        }

        public void Walk()
        {
            EnableMovement();
            _shootAnimator.StartWalking();
            _targetAnimatorSpeed = WalkingAnimSpeed;
        }

        public void Run()
        {
            EnableMovement();

            _shootAnimator.StartRunning();
            _targetAnimatorSpeed = RunningAnimSpeed;
        }

        public void StopAll()
        {
            StopMoving();
        }

        private void StopMoving()
        {
            _targetAnimatorSpeed = 0;
        }

        public void EnableMovement()
        {
            if (!_characterMovement.enabled)
                _characterMovement.enabled = true;
        }

        public void Idle()
        {
            StopMoving();

            _shootAnimator.StartIdle();
        }
    }
}