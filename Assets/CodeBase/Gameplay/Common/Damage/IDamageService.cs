using CodeBase.Gameplay.Healths;
using UnityEngine;

namespace CodeBase.Gameplay.Common.Damage
{
    public interface IDamageService
    {

        void ApplyDamage(RaycastHit hit, float baseDamage,  out Health target);
    }
}