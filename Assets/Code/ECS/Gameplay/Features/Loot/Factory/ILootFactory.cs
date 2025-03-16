using UnityEngine;

namespace Code.ECS.Gameplay.Features.Loot.Factory
{
    public interface ILootFactory
    {
        GameEntity CreateLootItem(LootTypeId lootTypeId, Vector3 at);
    }
}