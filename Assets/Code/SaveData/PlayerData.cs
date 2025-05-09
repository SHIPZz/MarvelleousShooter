using System;
using System.Collections.Generic;
using Code.ECS.Gameplay.Features.Shoots.Enums;

namespace Code.SaveData
{
    [Serializable]
    public class PlayerData
    {
        public GunTypeId LastGunId = GunTypeId.BasicRifle;
        public List<GunTypeId> AvailableGuns = new List<GunTypeId>() { GunTypeId.Knife , GunTypeId.WithoutGun, GunTypeId.BasicRifle};
        public float Hp = 100f;
    }
}