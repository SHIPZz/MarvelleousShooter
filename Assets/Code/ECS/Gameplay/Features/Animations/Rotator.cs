using System;
using DG.Tweening;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Animations
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private Ease _ease;
        [SerializeField] private Transform _rotate;
        [SerializeField] private Quaternion _to;

        private Action _onComplete;
        private Tween _tween;
        
        public bool TweenPlaying => _tween != null && _tween.IsPlaying();

        public void KillTween(bool complete = false)
        {
            _tween?.Kill(complete);
        }

        public void Init(Transform rotate, float duration = 1f, Ease ease = Ease.OutQuint, Action onComplete = null,
            Quaternion to = default)
        {
            _rotate = rotate;
            _to = to;
            _onComplete = onComplete;
            _ease = ease;
            _duration = duration;
        }

        public void DoLocalRotateQuaternion(Transform targetTransform, Quaternion target)
        {
            _tween = targetTransform
                .DOLocalRotateQuaternion(target, _duration)
                .SetEase(_ease)
                .OnComplete(() => _onComplete?.Invoke());
        }

        public void DoLocalRotateQuaternion()
        {
            _tween = _rotate
                .DOLocalRotateQuaternion(_to, _duration)
                .SetEase(_ease)
                .OnComplete(() => _onComplete?.Invoke());
        }

        public void DoLocalRotateQuaternion(Transform targetTransform, Quaternion target, float duration,
            Ease ease = Ease.OutQuint, Action onComplete = null)
        {
            _tween = targetTransform
                .DOLocalRotateQuaternion(target, duration)
                .SetEase(ease)
                .OnComplete(() => onComplete?.Invoke());
        }

        public void DoRotateQuaternion()
        {
            _tween = _rotate
                .DOLocalRotateQuaternion(_to, _duration)
                .SetEase(_ease)
                .OnComplete(() => _onComplete?.Invoke());
        }
    }
}