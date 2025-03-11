using CodeBase.Gameplay.Heroes.Enums;
using CodeBase.Gameplay.Shootables.Recoils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Configs
{
    [CreateAssetMenu(fileName = "ShootConfig", menuName = "Gameplay/ShootConfig")]
    public class ShootConfig : SerializedScriptableObject
    {
        public ShootTypeId ShootTypeId;
        public Shoot Prefab;
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
    }
}