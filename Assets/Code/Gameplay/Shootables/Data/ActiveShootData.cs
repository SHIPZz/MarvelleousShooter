using System;

namespace Code.Gameplay.Shootables.Data
{
    [Serializable]
    public class ActiveShootData
    {
        public ShootTypeId Id;
        public int Count;
        public int AmmoCount;
    }
}