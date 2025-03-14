using UnityEngine;

namespace Code.Gameplay.Shootables.Factory
{
    public interface IShootFactory
    {
        GameEntity Create(Transform parent, ShootTypeId shootTypeId);
    }
}