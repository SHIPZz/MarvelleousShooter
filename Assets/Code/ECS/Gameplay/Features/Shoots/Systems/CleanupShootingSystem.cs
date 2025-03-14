using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CleanupShootingSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupShootingSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting,
                GameMatcher.Shootable));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isShooting = false;
            }
        }
    }
}