using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Lifetime
{
    public class CleanUpHpRestoredSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanUpHpRestoredSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.HpRestored));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isHpRestored = false;
                entity.RemoveRestoreHp();
            }
        }
    }
}