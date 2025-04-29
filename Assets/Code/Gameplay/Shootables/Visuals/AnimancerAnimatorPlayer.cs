using System;
using System.Collections.Generic;
using Animancer;
using Code.Gameplay.Shootables.Visuals;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UniRx;
using UnityEngine;

namespace Code.Gameplay.Animations
{
    public class AnimancerAnimatorPlayer : SerializedMonoBehaviour
    {
        [OdinSerialize] private Dictionary<AnimationTypeId, ClipTransition> _animationClips;
        [SerializeField] private AnimancerComponent _animancer;
        
        private readonly Dictionary<AnimationTypeId, AnimancerState> _animationStates = new();

        private readonly Subject<AnimationTypeId> _animationRequested = new();
        
        public AnimationTypeId LastPlayingAnimation { get; private set; }

        private void Awake()
        {
            FillAnimationStates();
        }

        public bool IsPlaying(AnimationTypeId animationTypeId)
        {
            if (!_animationStates.ContainsKey(animationTypeId))
                return false;

            AnimancerState state = _animationStates[animationTypeId];
            
            return state.IsPlayingAndNotEnding();
        }
        
        public AnimancerState GetState(AnimationTypeId animationTypeId) =>
            _animationStates.GetValueOrDefault(animationTypeId);
        
        public async UniTask StartAnimation(AnimationTypeId animationTypeId,
            float fadeDuration = 0.2f, FadeMode fadeMode = FadeMode.FixedSpeed)
        {
            Debug.Log($"@@@ anim type start - {animationTypeId}");
            if (!_animationClips.TryGetValue(animationTypeId, out var clip))
                throw new Exception($"no animation for {animationTypeId}");

            ReportAnimationRequested(animationTypeId);
            
            AnimancerState state = _animancer.Play(clip, fadeDuration, fadeMode);

            _animationStates[animationTypeId] = state;
            
            LastPlayingAnimation = animationTypeId;

            await state;
        }

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

        private void ReportAnimationRequested(AnimationTypeId animationTypeId)
        {
            _animationRequested?.OnNext(animationTypeId);
        }
    }
}