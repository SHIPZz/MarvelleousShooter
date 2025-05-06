using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Movement.Configs;
using Code.ECS.View;
using Code.Gameplay.Animations;
using Code.Gameplay.Shootables;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;

namespace Code.Gameplay.Heroes.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Gameplay/HeroConfig", order = 1)]
    public class HeroConfig : SerializedScriptableObject
    {
        public EntityBehaviour Prefab;
        public ShootTypeId InitialWeapon;
        public float Hp = 100f;
        
        public MovementData MovementData = new();
        public LayerMask GroundDetectionMask;
        public float GroundDepth = 5f;
        public float GroundRadius = 1f;
        
         public float AnimationFadeDuration = 0.1f;
    }
}