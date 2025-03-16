using System;
using System.Collections.Generic;
using Code.Gameplay.Shootables;

namespace Code.SaveData
{
    [Serializable]
    public class PlayerData
    {
        public ShootTypeId LastWeaponId = ShootTypeId.BasicRifle;
        public List<ShootTypeId> AvailableShoots = new List<ShootTypeId>() { ShootTypeId.Knife , ShootTypeId.BasicRifle};
        public float Hp = 100f;
    }
}