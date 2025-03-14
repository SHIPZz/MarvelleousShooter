using System;
using Code.Gameplay.Healths;

namespace Code.Gameplay.Common.Damage
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