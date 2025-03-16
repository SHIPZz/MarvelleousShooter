using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Systems
{
    public class SetSpeedZeroOnNoGroundSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public SetSpeedZeroOnNoGroundSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Speed));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isOnGround)
                    entity.ReplaceSpeed(0);
            }
        }
    }
}