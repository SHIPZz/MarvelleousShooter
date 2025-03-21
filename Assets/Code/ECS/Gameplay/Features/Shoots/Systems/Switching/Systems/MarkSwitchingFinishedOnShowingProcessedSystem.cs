using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingFinishedOnShowingProcessedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public MarkSwitchingFinishedOnShowingProcessedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switchable,
                    GameMatcher.SwitchingStarted,
                    GameMatcher.ShowingProcessed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isSwitchingProcessed = true;
                entity.isSwitchingStarted = false;
                entity.isSwitchingProcessing = false;

                entity.isHidingProcessed = false;
                entity.isShowingProcessed = false;
            }
        }
    }
}