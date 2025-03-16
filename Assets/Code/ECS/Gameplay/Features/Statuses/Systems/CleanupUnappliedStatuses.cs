using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnappliedStatuses : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupUnappliedStatuses(GameContext game)
        {
            _statuses = game.GetGroup(GameMatcher.AllOf(GameMatcher.Status, GameMatcher.Unapplied));
        }

        public void Cleanup()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                status.isDestructed = true;
            }
        }
    }
}