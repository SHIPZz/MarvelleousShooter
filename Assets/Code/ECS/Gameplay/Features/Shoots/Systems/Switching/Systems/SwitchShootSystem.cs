using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Switching.Systems
{
    public class SwitchShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _shootHolders;
        private readonly List<GameEntity> _buffer = new(2);

        public SwitchShootSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootSwitchingRequested,
                    GameMatcher.Switchable,
                    GameMatcher.ShootSwitchingReady,
                    GameMatcher.ShootSwitchingAvailable
                ));

            _shootHolders = game.GetGroup(GameMatcher.AllOf(GameMatcher.ShootHolder,GameMatcher.CurrentGunId));
        }

        public void Execute()
        {
            foreach (GameEntity shootHolder in _shootHolders)
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplacePreviousSwitchedGunId(shootHolder.CurrentGunId);
                
                entity.isSwitching = true;
            }
        }
    }
}