using Code.ECS.Gameplay.Features.Effects;
using Code.ECS.Gameplay.Features.Shoots.Enums;
using Code.ECS.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Configs
{
    [CreateAssetMenu(fileName = "ShootConfig", menuName = "Gameplay/ShootConfig")]
    public class ShootConfig : SerializedScriptableObject
    {
        public GunTypeId gunTypeId;
        public EntityBehaviour Prefab;
        public float Сooldown = 0.1f;
        public int AmmoCount = 1;
        public float DamagePerHit = 5;
        public Vector3 Position;
        public Vector3 Rotation;

        public RecoilData RecoilData;
        public GunInputTypeId InputKey;

        public bool Reloadable = true;
        
        public bool CanAim = true;
        public bool CanRunAndShoot;
        public float ShootDistance = 100f;
        public LayerMask Mask;
        public bool HasIdleFocus;
        public EffectTypeId HitEffectTypeId = EffectTypeId.GoldSmallFireImpact;
        public bool CanRaycast = true;
        
        [Space]
        [Header("Move on shoot")]
        public float MoveGunDuration;
        public Vector3 MoveGunPosition;
    }
}