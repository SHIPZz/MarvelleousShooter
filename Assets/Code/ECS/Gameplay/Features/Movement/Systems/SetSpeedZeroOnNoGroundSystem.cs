using Code.ECS.Gameplay.Features.CharacterStats;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class SetSpeedZeroOnNoGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetSpeedZeroOnNoGroundSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Speed,GameMatcher.BaseStats));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isOnGround)
                    entity.BaseStats[Stats.Speed] = 0;
            }
        }
    }
}