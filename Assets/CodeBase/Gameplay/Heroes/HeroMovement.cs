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

        private bool _isMoving;
        private bool _stopped;
        private bool _isIdle;

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
            _isMoving = true;
        }

        public void Run()
        {
            EnableMovement();

            _shootAnimator.StartRunning();
            _targetAnimatorSpeed = RunningAnimSpeed;
            _isMoving = true;
        }

        public void StopAll()
        {
            StopMoving();
        }

        private void StopMoving()
        {
            _targetAnimatorSpeed = 0;
            _isMoving = false;
            _isIdle = false;
            _stopped = true;
        }

        public void EnableMovement()
        {
            if (!_characterMovement.enabled)
                _characterMovement.enabled = true;

            _stopped = false;
        }

        public void Idle()
        {
            if (_isIdle)
                return;

            StopMoving();

            _shootAnimator.StartIdle();
            _isIdle = true;
            _stopped = false;
        }

        public void StopIdle()
        {
            _stopped = true;
            _isIdle = false;
        }
    }
}