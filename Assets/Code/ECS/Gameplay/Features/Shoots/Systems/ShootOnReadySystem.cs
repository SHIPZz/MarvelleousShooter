using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class ShootOnReadySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public ShootOnReadySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootingReady,
                    GameMatcher.ShootingAvailable,
                    GameMatcher.ShootingRequested,
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
                entity.isShootAnimationFinished = false;
                entity.isShooting = true;
            }
        }
    }
}