using System;
using CodeBase.Gameplay.Shootables;

namespace CodeBase.SaveData
{
    [Serializable]
    public class PlayerData
    {
        public ShootTypeId LastWeaponId = ShootTypeId.BasicRifle;
    }
}