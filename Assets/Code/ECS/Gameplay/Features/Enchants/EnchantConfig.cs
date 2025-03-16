using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Statuses;
using Code.ECS.View;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Enchants
{
    [CreateAssetMenu(menuName = "Enchant config", fileName = "EnchantConfig")]
    public class EnchantConfig : ScriptableObject
    {
        public EnchantTypeId EnchantTypeId;
        public Sprite Icon;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public float Radius = 1f;

        public EntityBehaviour ViewPrefab;
    }
}