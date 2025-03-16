using System.Collections.Generic;
using Code.ECS.Common.Time;
using Entitas;

namespace Code.ECS.Gameplay.Features.Cooldown.Systems
{
    public class CalculateCooldownSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly ITimeService _timeService;
        private readonly List<GameEntity> _buffer = new(16);

        public CalculateCooldownSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Cooldown,
                    GameMatcher.CooldownLeft
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                entity.ReplaceCooldownLeft(entity.CooldownLeft - _timeService.DeltaTime);
                entity.isCooldownUp = false;

                if (entity.CooldownLeft <= 0)
                {
                    entity.isCooldownUp = true;
                    entity.RemoveCooldownLeft();
                }
            }
        }
    }
}