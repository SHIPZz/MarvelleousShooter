using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnappliedStatusLinkedChanges : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(128);
        private readonly GameContext _game;

        public CleanupUnappliedStatusLinkedChanges(GameContext game)
        {
            _game = game;
            
            _statuses = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Id,
                GameMatcher.Unapplied,
                GameMatcher.Status
            ));
        }

        public void Cleanup()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            foreach (GameEntity entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
            {
                entity.isDestructed = true;
            }
        }
    }
}