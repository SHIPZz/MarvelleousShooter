using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkCollectingAvailableOnEndPointReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public MarkCollectingAvailableOnEndPointReachedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.EndPointReached, 
                    GameMatcher.TargetsBuffer)
                .NoneOf(GameMatcher.CollectingAvailable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isCollectingAvailable = true;
            }
        }
    }
}