using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Statuses.Systems
{
    public class StatusDurationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statuses;
        private readonly ITimeService _timeService;

        public StatusDurationSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _statuses = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Status,
                    GameMatcher.Duration,
                    GameMatcher.TimeLeft
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity status in _statuses)
            {
                if (status.TimeLeft > 0) 
                    status.ReplaceTimeLeft(status.TimeLeft - _timeService.DeltaTime);
                else
                    status.isUnapplied = true;
            }
        }
    }
}