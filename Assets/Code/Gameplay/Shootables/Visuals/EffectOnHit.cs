using Code.Gameplay.Effects;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Shootables.Visuals
{
    public class EffectOnHit : MonoBehaviour
    {
        public EffectTypeId EffectTypeId;

        [SerializeField] private Shoot _shoot;

        private IEffectFactory _effectFactory;

        [Inject]
        private void Construct(IEffectFactory effectFactory) => _effectFactory = effectFactory;

        private void Start() =>
            _shoot.ShootWithHitsEvent
                .Subscribe(Do)
            .AddTo(this);


        private void Do(RaycastHit[] raycastHits) =>
            _effectFactory
                .Create(EffectTypeId, null, raycastHits[0].point, Quaternion.LookRotation(raycastHits[0].normal))
                .Play();
    }
}