using Sirenix.OdinInspector;

namespace CodeBase.Gameplay.Effects
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "EffectSO", menuName = "Gameplay/EffectSO")]
    public class EffectSO : SerializedScriptableObject
    {
        public EffectTypeId EffectTypeId;
        public ParticleSystem ParticleSystem;
    }
}