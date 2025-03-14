using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Code.Gameplay.Shootables.Recoils
{
    [Serializable]
    public class RecoilData
    {
        [Header("Паттерн отдачи")] public Vector2[] Patterns;

        [Range(0, 100f)] public float Duration = 1f;
        [Range(0, 100f)] public float RecoverDuration = 5f;

        [SerializeField, Range(0, 10f)] private float _aimMultiplier = 0.5f;

        [SerializeField, Range(0, 10f)] private float _jumpMultiplier = 0.5f;

        [Range(0, 100f)] public float MinHorizontalRecoilOnJump = 2f;
        [Range(0, 100f)] public float MinVerticalRecoilOnJump = 2f;
        public Ease RecoverEase = Ease.OutQuint;

        public float AimMultiplier => _aimMultiplier <= 0 ? 1f : _aimMultiplier;
        public float JumpMultiplier => _jumpMultiplier <= 0 ? 1f : _jumpMultiplier;

        [Button]
        private void CreatePatternRandomly(int count, float rangeX, float rangeY)
        {
            Patterns = new Vector2[count];
            
            for (int i = 0; i < count - 1; i++)
            {
                Patterns[i] = new Vector2(UnityEngine.Random.Range(-rangeX, rangeX), UnityEngine.Random.Range(-rangeY, rangeY));
            }
        }
    }
}