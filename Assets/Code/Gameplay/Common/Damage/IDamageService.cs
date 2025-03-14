using Code.Gameplay.Healths;
using UnityEngine;

namespace Code.Gameplay.Common.Damage
{
    public interface IDamageService
    {

        void ApplyDamage(RaycastHit hit, float baseDamage,  out Health target);
    }
}