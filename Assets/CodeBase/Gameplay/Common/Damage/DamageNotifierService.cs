using System;
using CodeBase.Gameplay.Healths;

namespace CodeBase.Gameplay.Common.Damage
{
    public class DamageNotifierService : IDamageNotifierService
    {
        public event Action<Health> OnTargetPiercingDamaged; 
        public event Action<Health> OnTargetDamaged; 

        public void NotifyDamaged(Health health)
        {
            OnTargetDamaged?.Invoke(health);
        }

        public void NotifyPiercingDamage(Health health)
        {
            OnTargetDamaged?.Invoke(health);
            OnTargetPiercingDamaged?.Invoke(health);
        }
    }
}