using System.Collections.Generic;
using Code.ECS.View.Factory;
using Entitas;

namespace Code.ECS.View.Systems
{
    public class BindEntityViewFromViewPrefabSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IEntityViewFactory _entityViewFactory;
        private List<GameEntity> _buffer = new(128);

        public BindEntityViewFromViewPrefabSystem(GameContext game, IEntityViewFactory entityViewFactory)
        {
            _entityViewFactory = entityViewFactory;
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ViewPrefab)
                .NoneOf(GameMatcher.View));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                _entityViewFactory.CreateViewForEntityFromPrefab(entity);
            }
        }
    }
}