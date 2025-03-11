using CodeBase.Gameplay.Shootables;
using UnityEngine;

namespace CodeBase.Gameplay.Heroes.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Gameplay/HeroConfig", order = 1)]
    public class HeroConfig : ScriptableObject
    {
        public Hero Prefab;
        public ShootTypeId InitialWeapon;
    }
}