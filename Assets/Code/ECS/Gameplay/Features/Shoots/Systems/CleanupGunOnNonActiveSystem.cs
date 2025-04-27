using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CleanupGunOnNonActiveSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupGunOnNonActiveSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable)
                .NoneOf(GameMatcher.Active));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isShooting = false;
                entity.isShootingContinuously = false;
                entity.isShootingRequested = false;
                entity.isShootCooldownUp = true;
                entity.ReplaceShootCooldownLeft(0);
            }
        }
    }
}