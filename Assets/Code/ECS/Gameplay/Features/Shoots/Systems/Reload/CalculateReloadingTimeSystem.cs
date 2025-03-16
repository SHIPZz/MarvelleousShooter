using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Shoots.Systems.Reload
{
    public class CalculateReloadingTimeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;

        public CalculateReloadingTimeSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Reloading,
                    GameMatcher.ReloadTime, 
                    GameMatcher.ReloadTimeLeft
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceReloadTimeLeft(entity.ReloadTimeLeft - _timeService.DeltaTime);

                if (entity.ReloadTimeLeft <= 0)
                {
                    entity.isReloadTimeEnded = true;
                    entity.ReplaceReloadTimeLeft(0);
                }
            }
        }
    }
}