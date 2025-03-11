using CodeBase.Gameplay.Effects;
using UniRx;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Shootables.Visuals
{
    public class EffectOnShoot : MonoBehaviour
    {
        public Shoot Shoot;
        public EffectTypeId EffectTypeId;
        
        public Transform Parent;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = Vector3.one;
        public bool UseOwnPosition;
        
        private IEffectFactory _effectFactory;

        [Inject]
        private void Construct(IEffectFactory effectFactory) => _effectFactory = effectFactory;
        
        private void Start() => Shoot.ShootEvent
            .Subscribe(_ => Do())
            .AddTo(this);

        private void Do()
        {
            Effect effect = _effectFactory.Create(EffectTypeId, Parent, Position, Quaternion.Euler(Rotation), UseOwnPosition);

            effect.transform.localPosition = Position;
            effect.transform.localRotation = Quaternion.Euler(Rotation);
            effect.transform.localScale = Scale;
            
            effect.Play();
        }
    }
}