using UnityEngine;

namespace CodeBase.Gameplay.Shootables.Factory
{
    public interface IShootFactory
    {
        Shoot Create(Transform parent, ShootTypeId shootTypeId);
    }
}