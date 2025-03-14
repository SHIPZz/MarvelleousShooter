using System;
using UnityEngine;

namespace Code.Gameplay.AbilitySystem
{
    public abstract class AbstractAbility : IDisposable
    {
        protected float Duration = 15f;
        protected float Timer;
        
        public bool IsActive { get; protected set; }
        
        public virtual bool IsAlwaysActive { get; protected set; }
        
        public abstract AbilityTypeId AbilityType { get; protected set; }

        public abstract void OnGained(AbilityOwner AbilityOwner);

        public abstract void OnLose();

        public virtual void SetDuration(float duration)
        {
            Duration = duration;
        }

        public virtual void OnUpdate()
        {
            if(!IsActive || IsAlwaysActive)
                return;
            
            Timer += Time.deltaTime;
            
            if (Timer >= Duration)
            {
                OnLose();
                IsActive = false;
            }
        }

        public virtual void Dispose()
        {
            
        }
    }
}