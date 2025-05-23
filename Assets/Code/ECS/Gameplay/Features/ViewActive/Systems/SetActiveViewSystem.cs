﻿using Entitas;

namespace Code.ECS.Gameplay.Features.ViewActive.Systems
{
    public class SetActiveViewSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetActiveViewSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.View);
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (entity is { View: not null } && entity.View.gameObject != null)
                    entity.View.gameObject.SetActive(entity.isViewActive);
            }
        }
    }
}