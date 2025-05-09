using UnityEngine;

namespace Code.ECS.Gameplay.Features.Heroes.Factory
{
    public interface IHeroFactory
    {
        GameEntity Create(Transform parent, Vector3 at, Quaternion rotation);
    }
}