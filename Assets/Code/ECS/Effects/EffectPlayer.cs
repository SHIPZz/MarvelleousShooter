﻿using Code.ECS.Gameplay.Features.Effects;
using UnityEngine;
using Zenject;

namespace Code.ECS.Effects
{
    public class EffectPlayer : MonoBehaviour
    {
        public EffectTypeId EffectTypeId;
        
        public Transform Parent;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = Vector3.one;
        public bool UseOwnPosition;
        
        [Inject] private IEffectViewFactory _effectFactory;

        public void Play()
        {
            Effect effect = _effectFactory.Create(EffectTypeId, Parent, Position, Quaternion.Euler(Rotation), UseOwnPosition);

            effect.transform.localPosition = Position;
            effect.transform.localRotation = Quaternion.Euler(Rotation);
            effect.transform.localScale = Scale;
            
            effect.Play();
        }
    }
}