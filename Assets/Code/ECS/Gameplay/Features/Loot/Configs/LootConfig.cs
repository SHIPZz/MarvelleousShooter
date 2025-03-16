using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Statuses;
using Code.ECS.View;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Loot.Configs
{
    [CreateAssetMenu(fileName = "LootConfig", menuName = "Gameplay/LootConfig")]
    public class LootConfig : ScriptableObject
    {
        public LootTypeId Id;
        public float Experience;
        public EntityBehaviour ViewPrefab;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
        public float AnimationDuration = 1f;
        public AnimationCurve AnimationCurve;
    }
}