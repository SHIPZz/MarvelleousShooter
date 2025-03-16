using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Effects.Systems
{
    public class CleanupProcessedEffectsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(128);

        public CleanupProcessedEffectsSystem(GameContext game)
        {
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Effect, GameMatcher.Processed));
        }

        public void Cleanup()
        {
            foreach (GameEntity effect in _group.GetEntities(_buffer))
            {
                effect.Destroy();
            }
        }
    }
}