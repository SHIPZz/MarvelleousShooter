using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection.Systems
{
    public class DestructOnTargetBufferLimitReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public DestructOnTargetBufferLimitReachedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ProcessedTargetsBuffer,
                    GameMatcher.TargetLimit
                    )
                .NoneOf(GameMatcher.OverflowProcessedTargetsBuffer));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.ProcessedTargetsBuffer.Count >= entity.TargetLimit)
                {
                    entity.RemoveTargetCollectionComponents();
                    entity.isDestructed = true;
                }
            }
        }
    }
}