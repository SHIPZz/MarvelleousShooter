using System;
using System.Collections.Generic;
using Animancer;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public enum AnimationTypeId
    {
        None = 0,
        Shoot = 1,
        Reload = 2,
        Hide = 7,
        Idle = 8,
        Run = 9,
        Walk = 10,
        IdleFocus = 11,
        AimShoot = 12,
        Get = 13,
        AimIdle = 14,
        AimWalk = 15,
    }

    public enum TransitionTypeId
    {
        None = 0,
        Move = 1,
        AimMove = 2,
    }

    public class ShootAnimator : SerializedMonoBehaviour
    {
        public const int MovementLayer = 0;
        public const int ShootingLayer = 1;
        public const int ReloadLayer = 2;
        public const int AimLayer = 3;
        public const int HideLayer = 5;
        public const int BaseLayer = 6;
        public const int IdleLayer = 7;

        [SerializeField] private AnimancerComponent _animancer;
        [OdinSerialize] private Dictionary<AnimationTypeId, ClipTransition> _animationClips;
        [SerializeField] private StringAsset _moveSpeed;
        [OdinSerialize] private Dictionary<TransitionTypeId, TransitionAsset> _transitionAssets;

        private readonly Dictionary<AnimationTypeId, AnimancerState> _animationStates = new();
        private Dictionary<int, AnimancerLayer> _layers = new();

        public float GetMoveSpeed => _animancer.Parameters.GetFloat(_moveSpeed);

        public bool IsMovementLayerActive() => _layers[MovementLayer].IsAnyStatePlaying();

        public bool IsPlaying(AnimationTypeId animationTypeId) => _animationStates[animationTypeId].IsPlaying;

        public AnimancerState GetState(AnimationTypeId animationTypeId) =>
            _animationStates.GetValueOrDefault(animationTypeId);

        public ClipTransition GetClip(AnimationTypeId id) => _animationClips.GetValueOrDefault(id);

        public AnimancerComponent Animancer => _animancer;

        public bool AnimationPlaying(AnimationTypeId id) => _animationStates[id].IsPlaying;

        private void Awake()
        {
            InitLayers();

            FillAnimationStates();
        }

        [Button]
        public async UniTask StartAnimation(AnimationTypeId animationTypeId, int layer,
            float fadeDuration = 0.2f, FadeMode fadeMode = FadeMode.FixedSpeed)
        {
            Debug.Log($"@@@ anim type start - {animationTypeId}");
            if (!_animationClips.TryGetValue(animationTypeId, out var clip))
                throw new Exception("no animation");

            AnimancerState state = _animancer.Play(clip, fadeDuration, fadeMode);

            _animationStates[animationTypeId] = state;

            await state;
        }

        public UniTask StartShooting() => StartAnimation(AnimationTypeId.Shoot, ShootingLayer, 0.1f);

        public UniTask StartReloading() => StartAnimation(AnimationTypeId.Reload, ReloadLayer);

        public UniTask StartGetting() => StartAnimation(AnimationTypeId.Get, BaseLayer, 0.2f);

        public UniTask StartWalking() => StartAnimation(AnimationTypeId.Walk, MovementLayer);

        public UniTask StartRunning() => StartAnimation(AnimationTypeId.Run, MovementLayer);

        public void SetMoveSpeed(float moveSpeed) => _animancer.Parameters.SetValue(_moveSpeed, moveSpeed);

        public UniTask StartAim() => StartAnimation(AnimationTypeId.AimIdle, AimLayer);

        public UniTask StartAimWalk() => StartAnimation(AnimationTypeId.AimWalk, AimLayer);

        public UniTask StartIdleFocus() => StartAnimation(AnimationTypeId.IdleFocus, IdleLayer, 0.2f);

        public UniTask StartAimShooting() => StartAnimation(AnimationTypeId.AimShoot, ShootingLayer);

        public UniTask StartIdle() => StartAnimation(AnimationTypeId.Idle, IdleLayer, 0.2f);

        public UniTask StartHiding() => StartAnimation(AnimationTypeId.Hide, HideLayer, 0.2f);

        private UniTask PlayLayerTransition(int layerId, TransitionTypeId transitionId, float fadeDuration = 0.25f) =>
            _layers[layerId].Play(_transitionAssets[transitionId], fadeDuration).ToUniTask();

        private void FillAnimationStates()
        {
            foreach (var animationType in _animationClips.Keys)
            {
                if (_animationClips.TryGetValue(animationType, out var clip))
                {
                    AnimancerState state = _animancer.States.GetOrCreate(clip);
                    _animationStates[animationType] = state;
                }
            }
        }

        private void InitLayers()
        {
            _layers[MovementLayer] = _animancer.Layers[MovementLayer];
            _layers[ShootingLayer] = _animancer.Layers[ShootingLayer];
            _layers[ReloadLayer] = _animancer.Layers[ReloadLayer];
            _layers[AimLayer] = _animancer.Layers[AimLayer];
            _layers[HideLayer] = _animancer.Layers[HideLayer];
            _layers[IdleLayer] = _animancer.Layers[IdleLayer];
            _layers[BaseLayer] = _animancer.Layers[BaseLayer];
        }
    }
}