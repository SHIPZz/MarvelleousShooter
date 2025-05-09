using System.Collections.Generic;
using Animancer;
using Code.ECS.Gameplay.Features.Animations.Enums;
using Code.ECS.View;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Animations
{
    public class MarkCastRequiredOnAnimationEndToEntity : SerializedMonoBehaviour
    {
        [SerializeField] private EntityBehaviour _entityBehaviour;

        [OdinSerialize] private Dictionary<AnimationTypeId, StringAsset> _animationEvents = new();

        private void Start()
        {
            foreach ((AnimationTypeId animationTypeId, StringAsset eventName) in _animationEvents)
            {
                AnimancerAnimatorPlayer entityAnimancerAnimator = _entityBehaviour.Entity.AnimancerAnimator;

                AnimancerState animState = entityAnimancerAnimator.GetState(animationTypeId);

                animState.Events(this, out AnimancerEvent.Sequence events);
                
                events.AddCallbacks(eventName,MarkCastRequiredToEntity);
            }
        }

        private void MarkCastRequiredToEntity() => _entityBehaviour.Entity.isOnAnimationEndCastRequested = true;
    }
}