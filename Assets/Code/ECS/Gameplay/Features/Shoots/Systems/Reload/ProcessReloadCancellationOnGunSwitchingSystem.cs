using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class ProcessReloadCancellationOnGunSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _switching;
        private readonly List<GameEntity> _buffer = new(2);

        public ProcessReloadCancellationOnGunSwitchingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Shootable,
                    GameMatcher.Active,
                    GameMatcher.Reloading));

            _switching = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Active,
                GameMatcher.SwitchingProcessing));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            foreach (GameEntity switching in _switching)
            {
                entity.PutOnReload();
            }
        }
    }
}