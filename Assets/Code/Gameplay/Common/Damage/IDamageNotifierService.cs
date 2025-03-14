using System;
using Code.Gameplay.Healths;

namespace Code.Gameplay.Common.Damage
{
    public interface IDamageNotifierService
    {
        event Action<Health> OnTargetPiercingDamaged;
        event Action<Health> OnTargetDamaged;
        void NotifyDamaged(Health health);
        void NotifyPiercingDamage(Health health);
    }
}