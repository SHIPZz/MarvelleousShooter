using Code.ECS.Gameplay.Features.Shoots.Enums;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Factory
{
    public interface IShootFactory
    {
        GameEntity Create(Transform parent, GunTypeId gunTypeId, int ownerId);
    }
}