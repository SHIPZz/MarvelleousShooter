using Code.Gameplay.Cameras;
using Code.Gameplay.Cameras.Shake;
using Code.Gameplay.Common.Animations;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Heroes.Services;
using Code.Gameplay.Input;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Recoils
{
    public class Recoil : MonoBehaviour
    {
        [SerializeField] private RecoilData _recoilData;
        [SerializeField] private Rotator _rotator;

        private ICameraProvider _cameraProvider;
        private ITimeService _timeService;
        private ICameraShakeService _cameraShakeService;
        private IInputService _inputService;

        private float _duration;
        private int _shootPatternIndex;
        private float _horizontalRecoil;
        private float _verticalRecoil;
        private float _totalHorizontalRecoil;
        private float _totalVerticalRecoil;
        private IHeroService _heroService;

        [Inject]
        private void Construct(ICameraProvider cameraProvider,
            ICameraShakeService cameraShakeService,
            IInputService inputService,
            IHeroService heroService,
            ITimeService timeService)
        {
            _heroService = heroService;
            _inputService = inputService;
            _cameraShakeService = cameraShakeService;
            _timeService = timeService;
            _cameraProvider = cameraProvider;
        }

        private void Update()
        {
            Transform recoilRotator = _cameraProvider.RecoilRotator;

            if (_inputService.HasMouseAxis() && _rotator.TweenPlaying)
            {
                _rotator.KillTween();
            }
            
            if (_duration > 0)
            {
                SetRecoil(recoilRotator);

                _duration -= _timeService.DeltaTime;
            }
        }

        public void Init(RecoilData data)
        {
            _recoilData = data;

            _rotator.Init(rotate: _cameraProvider.RecoilRotator,
                duration: _recoilData.RecoverDuration,
                ease: _recoilData.RecoverEase,
                onComplete: ResetRecoilDirections,
                to: Quaternion.Euler(Vector3.zero));
        }

        public void ResetRecoil()
        {
            _shootPatternIndex = 0;
            _duration = 0;
            _rotator.KillTween();
            ResetCameraRotation();
        }

        public void GenerateRecoil()
        {
            _rotator.KillTween();

            _shootPatternIndex = NextShootPatternIndex(_shootPatternIndex);
            
            _duration = _recoilData.Duration;
            _cameraShakeService.ShakeByCameraForward();

            bool isAiming = _inputService.IsAiming();
            // var isHeroOnGround = _heroService.IsOnGround;

            CalculateRecoil(isAiming, true);

        }

        private int NextShootPatternIndex(int index) => Mathf.Clamp(index + 1,0,_recoilData.Patterns.Length - 1);

        private void ResetCameraRotation()
        {
            if (!Mathf.Approximately(_totalHorizontalRecoil, 0) || !Mathf.Approximately(_totalVerticalRecoil, 0))
            {
                _rotator.DoRotateQuaternion();
            }
        }

        private void SetRecoil(Transform rotator)
        {
            float deltaHorizontal = _horizontalRecoil * _timeService.DeltaTime;
            float deltaVertical = _verticalRecoil * _timeService.DeltaTime;

            rotator.eulerAngles -= new Vector3(deltaVertical, 0, 0);
            rotator.eulerAngles -= new Vector3(0, deltaHorizontal, 0);

            _totalHorizontalRecoil += deltaHorizontal;
            _totalVerticalRecoil += deltaVertical;
        }

        private void CalculateRecoil(bool isAiming, bool isHeroOnGround)
        {
            float aimMultiplier = isAiming ? _recoilData.AimMultiplier : 1f;
            float jumpMultiplier = isHeroOnGround ? 1f : _recoilData.JumpMultiplier;

            _horizontalRecoil = _recoilData.Patterns[_shootPatternIndex].x * aimMultiplier;
            _verticalRecoil = _recoilData.Patterns[_shootPatternIndex].y * aimMultiplier;

            ReCalculateRecoilOnGround(isHeroOnGround, jumpMultiplier);
        }

        private void ReCalculateRecoilOnGround(bool isHeroOnGround, float jumpMultiplier)
        {
            if (_horizontalRecoil <= 0 && !isHeroOnGround)
                _horizontalRecoil = _recoilData.MinHorizontalRecoilOnJump;

            if (_verticalRecoil <= 0 && !isHeroOnGround)
                _verticalRecoil = _recoilData.MinVerticalRecoilOnJump;

            _horizontalRecoil *= jumpMultiplier;
            _verticalRecoil *= jumpMultiplier;
        }

        private void ResetRecoilDirections()
        {
            _totalHorizontalRecoil = 0;
            _totalVerticalRecoil = 0;
        }
    }
}