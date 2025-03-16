using Entitas;
using UnityEngine;

namespace Code.ECS.Gameplay.Features.Shoots.Systems
{
    public class SetLastShootTimeOnShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetLastShootTimeOnShootingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Shootable, 
                GameMatcher.Shooting
                ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceLastShootTime(Time.time);
            }
        }
    }
}