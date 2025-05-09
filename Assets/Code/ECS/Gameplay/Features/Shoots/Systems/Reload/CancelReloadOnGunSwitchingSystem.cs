using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class CancelReloadOnGunSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _switching;
        private readonly List<GameEntity> _buffer = new(2);

        public CancelReloadOnGunSwitchingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gun,
                    GameMatcher.Reloading,
                    GameMatcher.ReloadTimeLeft
                    ));

            _switching = game.GetGroup(GameMatcher.SwitchingProcessing);
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switching)
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.PutOnReload();
            }
        }
    }
}