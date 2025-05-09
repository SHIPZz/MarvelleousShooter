using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Cleanups
{
    public class CleanupShootingStartedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupShootingStartedSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shooting,GameMatcher.ShootingStarted));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isShootingStarted = false;
            }
        }
    }
}