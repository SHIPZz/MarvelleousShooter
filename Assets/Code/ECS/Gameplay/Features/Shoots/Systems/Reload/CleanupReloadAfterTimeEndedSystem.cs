using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class CleanupReloadAfterTimeEndedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(16);

        public CleanupReloadAfterTimeEndedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                GameMatcher.ReloadTimeEnded,
                GameMatcher.ReloadTime,
                GameMatcher.ReloadTimeLeft
                ));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceReloadTimeLeft(entity.ReloadTime);
                entity.isReloadTimeEnded = false;
            }
        }
    }
}