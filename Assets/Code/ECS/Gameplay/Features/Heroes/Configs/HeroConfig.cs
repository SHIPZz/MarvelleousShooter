using Code.ECS.Gameplay.Features.Movement.Configs;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Code.ECS.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Heroes.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Gameplay/HeroConfig", order = 1)]
    public class HeroConfig : SerializedScriptableObject
    {
        public EntityBehaviour Prefab;
        public GunTypeId InitialWeapon;
        public float Hp = 100f;
        
        public MovementData MovementData = new();
        public LayerMask GroundDetectionMask;
        public float GroundDepth = 5f;
        public float GroundRadius = 1f;
        
         public float AnimationFadeDuration = 0.1f;
    }
}