using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class MarkSwitchingStartedSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkSwitchingStartedSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.ShootSwitchingAvailable,
                    GameMatcher.ShootSwitchingRequested));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                Debug.Log($"{entity.isHidingProcessing} - hiding");
                Debug.Log($"{entity.isShowingProcessing} - showing");
                entity.isSwitchingProcessed = false;
                entity.isSwitchingStarted = true;
            }
        }
    }
}