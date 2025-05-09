using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Configs
{
    [Serializable]
    public class RecoilData
    {
        [Header("Паттерн отдачи")] public Vector2[] Patterns;

        [Range(0, 100f)] public float Speed = 1f;
        [Range(0, 100f)] public float RecoverSpeed = 5f;

        [SerializeField, Range(0, 200)] private float _aimMultiplier = 0.5f;
        
        [SerializeField, Range(0, 200)] private float _aimJumpMultiplier = 3f;

        [SerializeField, Range(0, 200)] private float _jumpMultiplier = 0.5f;

        [Range(0, 100f)] public float MinHorizontalRecoilOnJump = 2f;
        [Range(0, 100f)] public float MinVerticalRecoilOnJump = 2f;
        
        public Ease RecoverEase = Ease.OutQuint;

        public float AimMultiplier => GetClampedMultiplier(_aimMultiplier);

        public float JumpMultiplier => GetClampedMultiplier(_jumpMultiplier);

        public float AimJumpMultiplier => GetClampedMultiplier(_aimJumpMultiplier);

        [Button]
        private void CreatePatternRandomly(int count, float rangeX, float rangeY)
        {
            Patterns = new Vector2[count];
            
            for (int i = 0; i < count - 1; i++)
            {
                Patterns[i] = new Vector2(UnityEngine.Random.Range(-rangeX, rangeX), UnityEngine.Random.Range(-rangeY, rangeY));
            }
        }

        private float GetClampedMultiplier(float multiplier)
        {
            return multiplier <= 0 ? 1f : multiplier;
        }
    }
}