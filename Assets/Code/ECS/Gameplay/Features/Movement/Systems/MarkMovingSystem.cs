using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class MarkMovingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public MarkMovingSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Movable,
                GameMatcher.BaseStats));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.isMoving = entity.BaseStats[Stats.Speed] > 0
                                  && entity.isOnGround
                                  && entity.isMovingRequested;
            }
        }
    }
}