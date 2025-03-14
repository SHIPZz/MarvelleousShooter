using UnityEngine;

namespace Code.Gameplay.Heroes.Factory
{
    public interface IHeroFactory
    {
        GameEntity Create(Transform parent, Vector3 at, Quaternion rotation);
    }
}