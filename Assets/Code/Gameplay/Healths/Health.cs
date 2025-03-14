using System;
using UnityEngine;

namespace Code.Gameplay.Healths
{
    public class Health : MonoBehaviour
    {
        [field: SerializeField] public float MaxValue { get; private set; } = 100f;

        [field: SerializeField] public float Value { get; private set; } = 100f;

        public event Action<float> ValueChanged;
        
        public bool Dead { get; private set; }

        public void Add(float value)
        {
            Value = Mathf.Clamp(Value + value, 0, MaxValue);

            ValueChanged?.Invoke(Value);
        }

        public void Decrease(float value)
        {
            Value = Mathf.Clamp(Value - value, 0, MaxValue);

            if (Value <= 0)
                Dead = true;

            ValueChanged?.Invoke(Value);
        }

        public bool CheckOnZero(float finalDamage)
        {
            return Value - finalDamage <= 0;
        }
    }
}