using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Movement.Jumping.Systems
{
    public class CalculateNoGroundTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public CalculateNoGroundTimeSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Movable,
                    GameMatcher.BaseStats,
                    GameMatcher.JumpForce
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                if (!entity.isOnGround)
                {
                    entity.noGroundTime.Value += _timeService.DeltaTime;
                }
                else
                {
                    entity.ReplaceNoGroundTime(0);
                }
            }
        }
    }
}