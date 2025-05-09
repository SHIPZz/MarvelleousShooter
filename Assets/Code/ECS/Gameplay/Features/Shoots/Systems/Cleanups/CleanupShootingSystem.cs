using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cleanups
{
    public class CleanupShootingSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(10);

        public CleanupShootingSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.ShootCooldownUp,
                GameMatcher.ShootCooldown,
                GameMatcher.Shooting,
                GameMatcher.Gun));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.ReplaceShootCooldownLeft(entity.ShootCooldown);
                entity.isShootCooldownUp = false;
                entity.isShooting = false;
            }
        }
    }
}