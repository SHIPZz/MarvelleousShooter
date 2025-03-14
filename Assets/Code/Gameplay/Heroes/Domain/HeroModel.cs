using System;
using System.Collections.Generic;
using Code.Gameplay.Shootables;

namespace Code.Gameplay.Heroes.Domain
{
    [Serializable]
    public class HeroModel
    {
        public ShootTypeId CurrentShoot;

        public List<ShootTypeId> AvailableShoots = new();

        public int Health;

        public int Armor;

    }
}