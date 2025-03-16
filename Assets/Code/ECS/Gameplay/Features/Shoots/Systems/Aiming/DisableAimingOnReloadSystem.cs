using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Aiming
{
    public class DisableAimingOnReloadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(2);

        public DisableAimingOnReloadSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Aimable));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isAimingAvailable = !entity.isReloading;

                if (entity.isReloading)
                    entity.isAiming = false;
            }
        }
    }
}