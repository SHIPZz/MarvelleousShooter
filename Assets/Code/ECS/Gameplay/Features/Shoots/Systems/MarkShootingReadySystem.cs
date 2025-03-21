using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkShootingReadySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingReadySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ShootInterval,
                    GameMatcher.ShootingRequested,
                    GameMatcher.Active,
                    GameMatcher.ViewActive,
                    GameMatcher.LastShootTime
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingReady = CanShoot(entity);
            }
        }

        private bool CanShoot(GameEntity entity)
        {
            return Time.time >= entity.LastShootTime + entity.ShootInterval 
                   && entity.isShootAnimationFinished;
        }
    }
}