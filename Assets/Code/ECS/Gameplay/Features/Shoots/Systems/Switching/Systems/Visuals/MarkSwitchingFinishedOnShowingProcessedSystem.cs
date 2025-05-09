using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class MarkSwitchingFinishedOnShowingProcessedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _switchings;
        private readonly List<GameEntity> _buffer = new(2);

        public MarkSwitchingFinishedOnShowingProcessedSystem(GameContext game)
        {
            _switchings = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Switchable,
                    GameMatcher.SwitchingStarted,
                    GameMatcher.ShowingProcessed));
        }

        public void Execute()
        {
            foreach (GameEntity switching in _switchings.GetEntities(_buffer))
            {
                switching.isSwitchingProcessed = true;
                switching.isSwitchingStarted = false;
                switching.isSwitchingProcessing = false;

                switching.isHidingProcessed = false;
                switching.isShowingProcessed = false;
            }
        }
    }
}