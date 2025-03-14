using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Effects
{
    [CreateAssetMenu(fileName = "EffectSO", menuName = "Gameplay/EffectSO")]
    public class EffectSO : SerializedScriptableObject
    {
        public EffectTypeId EffectTypeId;
        public ParticleSystem ParticleSystem;
    }
}