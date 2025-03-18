using Code.ECS.View;
using Code.Gameplay.Effects;
using Code.Gameplay.Heroes.Enums;
using Code.Gameplay.Shootables.Recoils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Shootables.Configs
{
    [CreateAssetMenu(fileName = "ShootConfig", menuName = "Gameplay/ShootConfig")]
    public class ShootConfig : SerializedScriptableObject
    {
        public ShootTypeId ShootTypeId;
        public EntityBehaviour Prefab;
        public float ShootInterval = 0.1f;
        public int AmmoCount = 1;
        public float DamagePerHit = 5;
        public Vector3 Position;
        public Vector3 Rotation;

        public RecoilData RecoilData;
        public ShootInputTypeId ShowKey;

        public bool Reloadable = true;
        
        public bool NeedFullAnimationPlay;

        public bool CanAim = true;
        public bool CanRunAndShoot;
        public float ShootDistance = 100f;
        public LayerMask Mask;
        public bool HasIdleFocus;
        public EffectTypeId HitEffectTypeId = EffectTypeId.GoldSmallFireImpact;
        public bool CanRaycast = true;
    }
}