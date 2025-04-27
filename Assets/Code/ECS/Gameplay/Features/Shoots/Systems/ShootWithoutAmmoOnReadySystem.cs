using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class ShootWithoutAmmoOnReadySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ShootWithoutAmmoOnReadySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
                    GameMatcher.ShootDistance,
                    GameMatcher.LayerMask,
                    GameMatcher.ShootWithoutAmmo,
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