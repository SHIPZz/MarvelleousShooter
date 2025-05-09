using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems.Visuals
{
    public class ClearVisualProcessingOnQuickSwitchingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public ClearVisualProcessingOnQuickSwitchingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SwitchingStarted,
                    GameMatcher.Switchable,
                    GameMatcher.ShowingProcessing,
                    GameMatcher.GunSwitchingRequested
                    )
                .NoneOf(GameMatcher.SameGunSelected))
                ;
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isHidingProcessed = false;
                entity.isHidingProcessing = false;
                
                entity.isShowingProcessing = false;
                entity.isShowingProcessed = false;
            }
        }
    }
}