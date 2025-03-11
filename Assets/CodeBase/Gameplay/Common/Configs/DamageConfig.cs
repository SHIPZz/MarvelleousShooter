namespace CodeBase.Gameplay.Common.Configs
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "DamageConfig", menuName = "Gameplay/DamageConfig", order = 1)]
    public class DamageConfig : ScriptableObject
    {
        public  float MaxThickness = 10f;
        public  float DamageReductionPerObject = 0.08f;
        public  float DamageReductionPerMeter = 0.1f;
    }
}