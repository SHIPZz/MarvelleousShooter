using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class MarkReloadRequestedOnNoAmmoSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(16);

        public MarkReloadRequestedOnNoAmmoSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Reloadable,
                    GameMatcher.Active,
                    GameMatcher.AmmoCount)
                .NoneOf(GameMatcher.Reloading));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                if (!entity.isAmmoAvailable)
                    entity.isReloading = true;
            }
        }
    }
}