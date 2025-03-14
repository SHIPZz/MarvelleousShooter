using System.Collections.Generic;
using Code.ECS.View.Factory;
using Entitas;

namespace Code.ECS.View.Systems
{
    public class BindEntityViewFromPathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEntityViewFactory _entityViewFactory;
        private readonly List<GameEntity> _buffer = new(128);

        public BindEntityViewFromPathSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPath)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _entityViewFactory.CreateViewForEntityFromPath(entity);
            }
        }
    }
}