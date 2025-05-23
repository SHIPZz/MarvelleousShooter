﻿using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class MarkShootingContinuouslySystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkShootingContinuouslySystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Gun, 
                    GameMatcher.HeroGun 
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isShootingContinuously = ShootingRequestedAndAvailable(entity);
            }
        }

        private static bool ShootingRequestedAndAvailable(GameEntity entity)
        {
            return entity.isShootingRequested && entity.isShootingAvailable;
        }
    }
}