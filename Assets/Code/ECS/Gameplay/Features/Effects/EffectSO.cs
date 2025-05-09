using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Effects
{
    [CreateAssetMenu(fileName = "EffectSO", menuName = "Gameplay/EffectSO")]
    public class EffectSO : SerializedScriptableObject
    {
        public EffectTypeId EffectTypeId;
        public ParticleSystem ParticleSystem;
    }
}