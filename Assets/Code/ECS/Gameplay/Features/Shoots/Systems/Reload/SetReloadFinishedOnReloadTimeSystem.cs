using System.Collections.Generic;
using Code.Gameplay.Shootables.Extensions;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class SetReloadFinishedOnReloadTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public SetReloadFinishedOnReloadTimeSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Reloading, 
                    GameMatcher.ReloadTimeEnded));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isReloading = false;
                entity.isReloadingFinished = true;
                entity.PutOnAmmo();
            }
        }
    }
}