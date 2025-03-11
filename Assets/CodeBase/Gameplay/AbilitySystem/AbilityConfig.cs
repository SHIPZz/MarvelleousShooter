using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.AbilitySystem
{
    [CreateAssetMenu(fileName = nameof(AbilityConfig), menuName = "Gameplay/Ability config")]
    public class AbilityConfig : SerializedScriptableObject
    {
        public AbilityTypeId AbilityTypeId;

        public float Duration;
        public float Period;
        public int Pierce;
        public float Damage;
    }
}