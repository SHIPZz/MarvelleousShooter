using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class ShootOnCooldownUpSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ShootOnCooldownUpSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
                    GameMatcher.ShootCooldownUp,
                    GameMatcher.Active,
                    GameMatcher.AmmoAvailable,
                    GameMatcher.ShootDistance,
                    GameMatcher.LayerMask,
                    GameMatcher.Shootable
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShooting = true;
                entity.isShootingStarted = true;
            }
        }
    }
}