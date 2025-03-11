using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CodeBase.Gameplay.Shootables
{
    public class AmmoCount : MonoBehaviour
    {
       [ShowInInspector] public int Value { get; private set; }
       
       public int MaxValue { get; private set; }
       
       public bool HasAmmo => Value > 0;
       public bool NoAmmo => !HasAmmo;

       public event Action<int> Changed;

       public void Init(int value)
       {
           Value = Mathf.Max(0, value);
           MaxValue = value;
       }
        
        public void Increase(int value)
        {
            Value = Mathf.Clamp(Value + value,0, MaxValue);
            
            Changed?.Invoke(Value);
        }
        
        public void Decrease(int value)
        {
            Value = Mathf.Clamp(Value - value,0, MaxValue);

            Debug.Log($"Decrease");
            
            Changed?.Invoke(Value);
        }
    }
}