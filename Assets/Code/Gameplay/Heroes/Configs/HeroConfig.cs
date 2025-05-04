using Code.ECS.Gameplay.Features.Movement.Configs;
using Code.ECS.View;
using Code.Gameplay.Shootables;
using UnityEngine;

namespace Code.Gameplay.Heroes.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Gameplay/HeroConfig", order = 1)]
    public class HeroConfig : ScriptableObject
    {
        public EntityBehaviour Prefab;
        public ShootTypeId InitialWeapon;
        public float Hp = 100f;
        
        public MovementData MovementData = new();
        public LayerMask GroundDetectionMask;
        public float GroundDepth = 5f;
        public float GroundRadius = 1f;
    }
}