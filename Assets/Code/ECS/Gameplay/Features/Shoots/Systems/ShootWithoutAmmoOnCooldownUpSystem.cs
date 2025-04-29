using System.Collections.Generic;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class ShootWithoutAmmoOnCooldownUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public ShootWithoutAmmoOnCooldownUpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
                    GameMatcher.ShootDistance,
                    GameMatcher.ShootCooldownUp,
                    GameMatcher.Active,
                    GameMatcher.LayerMask,
                    GameMatcher.ShootWithoutAmmo,
                    GameMatcher.Shootable
                ).NoneOf(GameMatcher.Shooting));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.isShooting = true;
                entity.isShootingStarted = true;
            }
        }
    }
}