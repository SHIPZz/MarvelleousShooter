using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Jumping.Systems
{
    public class CleanupJumpSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(12);

        public CleanupJumpSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.JumpForce,GameMatcher.JumpingRequested));
        }

        public void Cleanup()
        {
            foreach (GameEntity entity in _group.GetEntities(_buffer))
            {
                entity.isJumpingRequested = false;
                entity.isJumping = false;
            }
        }
    }
}