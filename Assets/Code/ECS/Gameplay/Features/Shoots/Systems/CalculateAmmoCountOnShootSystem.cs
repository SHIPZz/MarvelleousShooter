using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class CalculateAmmoCountOnShootSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(128);

        public CalculateAmmoCountOnShootSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Shootable,
                    GameMatcher.Shooting,
                    GameMatcher.AmmoCount,
                    GameMatcher.AmmoAvailable,
                    GameMatcher.AmmoCountLeft));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceAmmoCountLeft(entity.AmmoCountLeft - 1);

                if (entity.AmmoCountLeft <= 0)
                {
                    entity.ReplaceAmmoCountLeft(0);
                    entity.isAmmoAvailable = false;
                }
            }
        }
    }
}