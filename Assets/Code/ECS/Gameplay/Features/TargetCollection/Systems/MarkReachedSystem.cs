﻿using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.TargetCollection.Systems
{
    public class MarkReachedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public MarkReachedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.TargetsBuffer)
                .NoneOf(GameMatcher.Reached));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (entity.TargetsBuffer.Count > 0)
                    entity.isReached = true;
            }
        }
    }
}