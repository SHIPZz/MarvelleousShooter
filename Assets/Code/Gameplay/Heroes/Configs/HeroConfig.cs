using Code.ECS.View;
using Code.Gameplay.Shootables;
using UnityEngine;

namespace Code.Gameplay.Heroes.Configs
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Gameplay/HeroConfig", order = 1)]
    public class HeroConfig : ScriptableObject
    {
        public EntityBehaviour Prefab;
        public ShootTypeId InitialWeapon;
    }
}