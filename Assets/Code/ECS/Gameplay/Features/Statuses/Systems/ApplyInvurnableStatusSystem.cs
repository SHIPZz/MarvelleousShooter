using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class ApplyInvurnableStatusSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly List<GameEntity> _buffer = new(32);
        private GameContext _game;

        public ApplyInvurnableStatusSystem(GameContext game)
        {
            _game = game;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.Status,
                    GameMatcher.InvulnerableStatus,
                    GameMatcher.ProducerId,
                    GameMatcher.TargetId,
                    GameMatcher.EffectValue)
                .NoneOf(GameMatcher.Affected));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses.GetEntities(_buffer))
            {
                GameEntity entityWithId = _game.GetEntityWithId(status.TargetId);

                entityWithId.isInvulnerable = true;

                status.isAffected = true;
            }
        }
    }
}